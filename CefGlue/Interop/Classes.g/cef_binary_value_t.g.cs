﻿//
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
//
namespace Xilium.CefGlue.Interop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Security;
    
    [StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
    [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable")]
    internal unsafe struct cef_binary_value_t
    {
        internal cef_base_t _base;
        internal IntPtr _is_valid;
        internal IntPtr _is_owned;
        internal IntPtr _is_same;
        internal IntPtr _is_equal;
        internal IntPtr _copy;
        internal IntPtr _get_size;
        internal IntPtr _get_data;
        
        // Create
        [DllImport(libcef.DllName, EntryPoint = "cef_binary_value_create", CallingConvention = libcef.CEF_CALL)]
        public static extern cef_binary_value_t* create(void* data, UIntPtr data_size);
        
        [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
        #if !DEBUG
        [SuppressUnmanagedCodeSecurity]
        #endif
        private delegate void add_ref_delegate(cef_binary_value_t* self);
        
        [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
        #if !DEBUG
        [SuppressUnmanagedCodeSecurity]
        #endif
        private delegate int release_delegate(cef_binary_value_t* self);
        
        [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
        #if !DEBUG
        [SuppressUnmanagedCodeSecurity]
        #endif
        private delegate int has_one_ref_delegate(cef_binary_value_t* self);
        
        [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
        #if !DEBUG
        [SuppressUnmanagedCodeSecurity]
        #endif
        private delegate int is_valid_delegate(cef_binary_value_t* self);
        
        [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
        #if !DEBUG
        [SuppressUnmanagedCodeSecurity]
        #endif
        private delegate int is_owned_delegate(cef_binary_value_t* self);
        
        [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
        #if !DEBUG
        [SuppressUnmanagedCodeSecurity]
        #endif
        private delegate int is_same_delegate(cef_binary_value_t* self, cef_binary_value_t* that);
        
        [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
        #if !DEBUG
        [SuppressUnmanagedCodeSecurity]
        #endif
        private delegate int is_equal_delegate(cef_binary_value_t* self, cef_binary_value_t* that);
        
        [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
        #if !DEBUG
        [SuppressUnmanagedCodeSecurity]
        #endif
        private delegate cef_binary_value_t* copy_delegate(cef_binary_value_t* self);
        
        [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
        #if !DEBUG
        [SuppressUnmanagedCodeSecurity]
        #endif
        private delegate UIntPtr get_size_delegate(cef_binary_value_t* self);
        
        [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
        #if !DEBUG
        [SuppressUnmanagedCodeSecurity]
        #endif
        private delegate UIntPtr get_data_delegate(cef_binary_value_t* self, void* buffer, UIntPtr buffer_size, UIntPtr data_offset);
        
        // AddRef
        private static IntPtr _p0;
        private static add_ref_delegate _d0;
        
        public static void add_ref(cef_binary_value_t* self)
        {
            add_ref_delegate d;
            var p = self->_base._add_ref;
            if (p == _p0) { d = _d0; }
            else
            {
                d = (add_ref_delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(add_ref_delegate));
                if (_p0 == IntPtr.Zero) { _d0 = d; _p0 = p; }
            }
            d(self);
        }
        
        // Release
        private static IntPtr _p1;
        private static release_delegate _d1;
        
        public static int release(cef_binary_value_t* self)
        {
            release_delegate d;
            var p = self->_base._release;
            if (p == _p1) { d = _d1; }
            else
            {
                d = (release_delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(release_delegate));
                if (_p1 == IntPtr.Zero) { _d1 = d; _p1 = p; }
            }
            return d(self);
        }
        
        // HasOneRef
        private static IntPtr _p2;
        private static has_one_ref_delegate _d2;
        
        public static int has_one_ref(cef_binary_value_t* self)
        {
            has_one_ref_delegate d;
            var p = self->_base._has_one_ref;
            if (p == _p2) { d = _d2; }
            else
            {
                d = (has_one_ref_delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(has_one_ref_delegate));
                if (_p2 == IntPtr.Zero) { _d2 = d; _p2 = p; }
            }
            return d(self);
        }
        
        // IsValid
        private static IntPtr _p3;
        private static is_valid_delegate _d3;
        
        public static int is_valid(cef_binary_value_t* self)
        {
            is_valid_delegate d;
            var p = self->_is_valid;
            if (p == _p3) { d = _d3; }
            else
            {
                d = (is_valid_delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(is_valid_delegate));
                if (_p3 == IntPtr.Zero) { _d3 = d; _p3 = p; }
            }
            return d(self);
        }
        
        // IsOwned
        private static IntPtr _p4;
        private static is_owned_delegate _d4;
        
        public static int is_owned(cef_binary_value_t* self)
        {
            is_owned_delegate d;
            var p = self->_is_owned;
            if (p == _p4) { d = _d4; }
            else
            {
                d = (is_owned_delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(is_owned_delegate));
                if (_p4 == IntPtr.Zero) { _d4 = d; _p4 = p; }
            }
            return d(self);
        }
        
        // IsSame
        private static IntPtr _p5;
        private static is_same_delegate _d5;
        
        public static int is_same(cef_binary_value_t* self, cef_binary_value_t* that)
        {
            is_same_delegate d;
            var p = self->_is_same;
            if (p == _p5) { d = _d5; }
            else
            {
                d = (is_same_delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(is_same_delegate));
                if (_p5 == IntPtr.Zero) { _d5 = d; _p5 = p; }
            }
            return d(self, that);
        }
        
        // IsEqual
        private static IntPtr _p6;
        private static is_equal_delegate _d6;
        
        public static int is_equal(cef_binary_value_t* self, cef_binary_value_t* that)
        {
            is_equal_delegate d;
            var p = self->_is_equal;
            if (p == _p6) { d = _d6; }
            else
            {
                d = (is_equal_delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(is_equal_delegate));
                if (_p6 == IntPtr.Zero) { _d6 = d; _p6 = p; }
            }
            return d(self, that);
        }
        
        // Copy
        private static IntPtr _p7;
        private static copy_delegate _d7;
        
        public static cef_binary_value_t* copy(cef_binary_value_t* self)
        {
            copy_delegate d;
            var p = self->_copy;
            if (p == _p7) { d = _d7; }
            else
            {
                d = (copy_delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(copy_delegate));
                if (_p7 == IntPtr.Zero) { _d7 = d; _p7 = p; }
            }
            return d(self);
        }
        
        // GetSize
        private static IntPtr _p8;
        private static get_size_delegate _d8;
        
        public static UIntPtr get_size(cef_binary_value_t* self)
        {
            get_size_delegate d;
            var p = self->_get_size;
            if (p == _p8) { d = _d8; }
            else
            {
                d = (get_size_delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(get_size_delegate));
                if (_p8 == IntPtr.Zero) { _d8 = d; _p8 = p; }
            }
            return d(self);
        }
        
        // GetData
        private static IntPtr _p9;
        private static get_data_delegate _d9;
        
        public static UIntPtr get_data(cef_binary_value_t* self, void* buffer, UIntPtr buffer_size, UIntPtr data_offset)
        {
            get_data_delegate d;
            var p = self->_get_data;
            if (p == _p9) { d = _d9; }
            else
            {
                d = (get_data_delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(get_data_delegate));
                if (_p9 == IntPtr.Zero) { _d9 = d; _p9 = p; }
            }
            return d(self, buffer, buffer_size, data_offset);
        }
        
    }
}
