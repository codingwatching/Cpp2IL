﻿using System.Diagnostics.CodeAnalysis;

namespace LibCpp2IL.MachO;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum LoadCommandId : uint
{
    LC_SEGMENT = 0x1,
    LC_SYMTAB = 0x2,
    LC_SYMSEG = 0x3,
    LC_THREAD = 0x4,
    LC_UNIXTHREAD = 0x5,
    LC_LOADFVMLIB = 0x6,
    LC_IDFVMLIB = 0x7,
    LC_IDENT = 0x8,
    LC_FVMFILE = 0x9,
    LC_PREPAGE = 0xa,
    LC_DYSYMTAB = 0xb,
    LC_LOAD_DYLIB = 0xc,
    LC_ID_DYLIB = 0xd,
    LC_LOAD_DYLINKER = 0xe,
    LC_ID_DYLINKER = 0xf,
    LC_PREBOUND_DYLIB = 0x10,
    LC_ROUTINES = 0x11,
    LC_SUB_FRAMEWORK = 0x12,
    LC_SUB_UMBRELLA = 0x13,
    LC_SUB_CLIENT = 0x14,
    LC_SUB_LIBRARY = 0x15,
    LC_TWOLEVEL_HINTS = 0x16,
    LC_PREBIND_CKSUM = 0x17,
    LC_LOAD_WEAK_DYLIB = 0x18 | 0x80000000,
    LC_SEGMENT_64 = 0x19,
    LC_ROUTINES_64 = 0x1a,
    LC_UUID = 0x1b,
    LC_RPATH = 0x1c | 0x80000000,
    LC_CODE_SIGNATURE = 0x1d,
    LC_SEGMENT_SPLIT_INFO = 0x1e,
    LC_REEXPORT_DYLIB = 0x1f | 0x80000000,
    LC_LAZY_LOAD_DYLIB = 0x20,
    LC_ENCRYPTION_INFO = 0x21,
    LC_DYLD_INFO = 0x22,
    LC_DYLD_INFO_ONLY = LC_DYLD_INFO | 0x80000000,
    LC_LOAD_UPWARD_DYLIB = 0x23 | 0x80000000,
    LC_VERSION_MIN_MACOSX = 0x24,
    LC_VERSION_MIN_IPHONEOS = 0x25,
    LC_FUNCTION_STARTS = 0x26,
    LC_DYLD_ENVIRONMENT = 0x27,
    LC_MAIN = 0x28 | 0x80000000,
    LC_DATA_IN_CODE = 0x29,
    LC_SOURCE_VERSION = 0x2a,
    LC_DYLIB_CODE_SIGN_DRS = 0x2b,
    LC_ENCRYPTION_INFO_64 = 0x2c,
    LC_LINKER_OPTION = 0x2d,
    LC_LINKER_OPTIMIZATION_HINT = 0x2e,
    LC_VERSION_MIN_TVOS = 0x2f,
    LC_VERSION_MIN_WATCHOS = 0x30,
    LC_NOTE = 0x31,
    LC_BUILD_VERSION = 0x32,
    LC_DYLD_EXPORTS_TRIE = 0x33 | 0x80000000,
    LC_DYLD_CHAINED_FIXUPS = 0x34 | 0x80000000,
    LC_LOAD_WEAK_DYLIB_UUID_REEXPORT_DYLIB = 0x35,
    LC_UUID_DYLIB_CODE_SIGN_DRS = 0x36,
    LC_DYLD_CHAINED_FIXUPS_COUNT = 0x37,
    LC_FUNCTION_STARTS_64 = 0x38,
    LC_DYLD_DEBUG = 0x39,
    LC_DYLD_CHAINED_FRAMEWORK = 0x3a,
    LC_DYLD_CHAINED_DYLIB = 0x3b,
    LC_LOAD_DYLINKER_WITH_LIBRARY_PATH = 0x3c,
}
