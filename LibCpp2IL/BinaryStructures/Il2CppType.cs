using System;
using LibCpp2IL.Metadata;

#pragma warning disable 8618
//Disable null check because this stuff is initialized by reflection
namespace LibCpp2IL.BinaryStructures
{
    public class Il2CppType
    {
        public ulong datapoint;
        public uint bits;
        public Union data { get; set; }
        public uint attrs { get; set; }
        public Il2CppTypeEnum type { get; set; }
        public uint num_mods { get; set; }
        public uint byref { get; set; }
        public uint pinned { get; set; }
        public uint valuetype { get; set; }

        public void Init()
        {
            attrs = bits & 0b1111_1111_1111_1111; //Lowest 16 bits
            type = (Il2CppTypeEnum) ((bits >> 16) & 0b1111_1111); //Bits 16-23
            data = new Union {dummy = datapoint};
            
            if (LibCpp2IlMain.Il2CppTypeHasNumMods5Bits)
            {
                //Unity 2021 (v27.2) changed num_mods to be 5 bits not 6
                //Which shifts byref and pinned left one
                //And adds a new bit 31 which is valuetype
                num_mods = (bits >> 24) & 0b1_1111;
                byref = (bits >> 29) & 1;
                pinned = (bits >> 30) & 1;
                valuetype = bits >> 31;
            }
            else
            {
                num_mods = (bits >> 24) & 0b11_1111;
                byref = (bits >> 30) & 1;
                pinned = bits >> 31;
                valuetype = 0;
            }
        }

        public class Union
        {
            public ulong dummy;
            public long classIndex => (long) dummy;
            public ulong type => dummy;
            public ulong array => dummy;
            public long genericParameterIndex => (long) dummy;
            public ulong generic_class => dummy;
        }

        public Il2CppTypeDefinition AsClass()
        {
            if(type is not Il2CppTypeEnum.IL2CPP_TYPE_CLASS and not Il2CppTypeEnum.IL2CPP_TYPE_VALUETYPE)
                throw new Exception("Type is not a class");

            return LibCpp2IlMain.TheMetadata!.typeDefs[data.classIndex];
        }

        public Il2CppType GetEncapsulatedType()
        {
            if(type is not Il2CppTypeEnum.IL2CPP_TYPE_PTR and not Il2CppTypeEnum.IL2CPP_TYPE_SZARRAY)
                throw new Exception("Type does not have a encapsulated type - it is not a pointer or an szarray");

            return LibCpp2IlMain.Binary!.GetIl2CppTypeFromPointer(data.type);
        }

        public Il2CppArrayType GetArrayType()
        {
            if(type is not Il2CppTypeEnum.IL2CPP_TYPE_ARRAY)
                throw new Exception("Type is not an array");
            
            return LibCpp2IlMain.Binary!.ReadClassAtVirtualAddress<Il2CppArrayType>(data.array);
        }

        public Il2CppType GetArrayElementType() => LibCpp2IlMain.Binary!.GetIl2CppTypeFromPointer(GetArrayType().etype);
        
        public int GetArrayRank() => GetArrayType().rank;

        public Il2CppGenericParameter GetGenericParameterDef()
        {
            if(type is not Il2CppTypeEnum.IL2CPP_TYPE_VAR and not Il2CppTypeEnum.IL2CPP_TYPE_MVAR)
                throw new Exception("Type is not a generic parameter");
            
            return LibCpp2IlMain.TheMetadata!.genericParameters[data.genericParameterIndex];
        }

        public Il2CppGenericClass GetGenericClass()
        {
            if(type is not Il2CppTypeEnum.IL2CPP_TYPE_GENERICINST)
                throw new Exception("Type is not a generic class");
            
            return LibCpp2IlMain.Binary!.ReadClassAtVirtualAddress<Il2CppGenericClass>(data.generic_class);
        }
    }
}