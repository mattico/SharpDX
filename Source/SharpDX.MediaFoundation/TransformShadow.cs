// Copyright (c) 2018 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using SharpDX;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace SharpDX.MediaFoundation
{
    /// <summary>
    /// Internal Transform Callback
    /// </summary>
    internal class TransformShadow : ComObjectShadow
    {
        private static readonly TransformVtbl Vtbl = new TransformVtbl();

        /// <summary>
        /// Return a pointer to the unmanaged version of this callback.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <returns>A pointer to a shadow c++ callback</returns>
        public static IntPtr ToIntPtr(ITransform transform)
        {
            return ToCallbackPtr<ITransform>(transform);
        }

        protected unsafe class TransformVtbl : ComObjectVtbl
        {
            public TransformVtbl() : base(23)
            {
                AddMethod(new GetStreamLimitsDelegate(GetStreamLimits));
                AddMethod(new GetStreamCountDelegate(GetStreamCount));
                AddMethod(new GetStreamIDsDelegate(GetStreamIDs));
                AddMethod(new GetInputStreamInfoDelegate(GetInputStreamInfo));
                AddMethod(new GetOutputStreamInfoDelegate(GetOutputStreamInfo));
                AddMethod(new GetAttributesDelegate(GetAttributes));
                AddMethod(new GetInputStreamAttributesDelegate(GetInputStreamAttributes));
                AddMethod(new GetOutputStreamAttributesDelegate(GetOutputStreamAttributes));
                AddMethod(new DeleteInputStreamDelegate(DeleteInputStream));
                AddMethod(new AddInputStreamsDelegate(AddInputStreams));
                AddMethod(new GetInputAvailableTypeDelegate(GetInputAvailableType));
                AddMethod(new GetOutputAvailableTypeDelegate(GetOutputAvailableType));
                AddMethod(new SetInputTypeDelegate(SetInputType));
                AddMethod(new SetOutputTypeDelegate(SetOutputType));
                AddMethod(new GetInputCurrentTypeDelegate(GetInputCurrentType));
                AddMethod(new GetOutputCurrentTypeDelegate(GetOutputCurrentType));
                AddMethod(new GetInputStatusDelegate(GetInputStatus));
                AddMethod(new GetOutputStatusDelegate(GetOutputStatus));
                AddMethod(new SetOutputBoundsDelegate(SetOutputBounds));
                AddMethod(new ProcessEventDelegate(ProcessEvent));
                AddMethod(new ProcessMessageDelegate(ProcessMessage));
                AddMethod(new ProcessInputDelegate(ProcessInput));
                AddMethod(new ProcessOutputDelegate(ProcessOutput));
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetStreamLimitsDelegate(IntPtr thisObject, void* arg0, void* arg1, void* arg2, void* arg3);
            private static unsafe int GetStreamLimits(IntPtr thisObject, void* param0, void* param1, void* param2, void* param3)
            {
                try
                {
                    Result result = default(Result);
                    ref int dwInputMinimumRef = ref Unsafe.AsRef<int>(param0);
                    ref int dwInputMaximumRef = ref Unsafe.AsRef<int>(param1);
                    ref int dwOutputMinimumRef = ref Unsafe.AsRef<int>(param2);
                    ref int dwOutputMaximumRef = ref Unsafe.AsRef<int>(param3);
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetStreamLimits(out dwInputMinimumRef, out dwInputMaximumRef, out dwOutputMinimumRef, out dwOutputMaximumRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetStreamCountDelegate(IntPtr thisObject, void* arg0, void* arg1);
            private static unsafe int GetStreamCount(IntPtr thisObject, void* param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    ref int cInputStreamsRef = ref Unsafe.AsRef<int>(param0);
                    ref int cOutputStreamsRef = ref Unsafe.AsRef<int>(param1);
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetStreamCount(out cInputStreamsRef, out cOutputStreamsRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetStreamIDsDelegate(IntPtr thisObject, int arg0, void* arg1, int arg2, void* arg3);
            private static unsafe int GetStreamIDs(IntPtr thisObject, int param0, void* param1, int param2, void* param3)
            {
                try
                {
                    Result result = default(Result);
                    int dwInputIDArraySize = default(int);
                    dwInputIDArraySize = (int)param0;
                    ref int* dwInputIDsRef = ref Unsafe.AsRef<int*>(param1);
                    int dwOutputIDArraySize = default(int);
                    dwOutputIDArraySize = (int)param2;
                    ref int* dwOutputIDsRef = ref Unsafe.AsRef<int*>(param3);
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetStreamIDs(dwInputIDArraySize, dwInputIDsRef, dwOutputIDArraySize, dwOutputIDsRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetInputStreamInfoDelegate(IntPtr thisObject, int arg0, void* arg1);
            private static unsafe int GetInputStreamInfo(IntPtr thisObject, int param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    int dwInputStreamID = default(int);
                    dwInputStreamID = (int)param0;
                    ref TransformInputStreamInfo streamInfoRef = ref Unsafe.AsRef<TransformInputStreamInfo>(param1);
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetInputStreamInfo(dwInputStreamID, out streamInfoRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetOutputStreamInfoDelegate(IntPtr thisObject, int arg0, void* arg1);
            private static unsafe int GetOutputStreamInfo(IntPtr thisObject, int param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    int dwOutputStreamID = default(int);
                    dwOutputStreamID = (int)param0;
                    ref TransformOutputStreamInfo streamInfoRef = ref Unsafe.AsRef<TransformOutputStreamInfo>(param1);
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetOutputStreamInfo(dwOutputStreamID, out streamInfoRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetAttributesDelegate(IntPtr thisObject, void* arg0);
            private static unsafe int GetAttributes(IntPtr thisObject, void* param0)
            {
                try
                {
                    Result result = default(Result);
                    ref IntPtr attributesRef_ = ref Unsafe.AsRef<IntPtr>(param0);
                    MediaAttributes attributesRef;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetAttributes(out attributesRef);
                    attributesRef_ = SharpDX.CppObject.ToCallbackPtr<MediaAttributes>(attributesRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetInputStreamAttributesDelegate(IntPtr thisObject, int arg0, void* arg1);
            private static unsafe int GetInputStreamAttributes(IntPtr thisObject, int param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    int dwInputStreamID = default(int);
                    dwInputStreamID = (int)param0;
                    ref IntPtr attributesRef_ = ref Unsafe.AsRef<IntPtr>(param1);
                    MediaAttributes attributesRef;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetInputStreamAttributes(dwInputStreamID, out attributesRef);
                    attributesRef_ = SharpDX.CppObject.ToCallbackPtr<MediaAttributes>(attributesRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetOutputStreamAttributesDelegate(IntPtr thisObject, int arg0, void* arg1);
            private static unsafe int GetOutputStreamAttributes(IntPtr thisObject, int param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    int dwOutputStreamID = default(int);
                    dwOutputStreamID = (int)param0;
                    ref IntPtr attributesRef_ = ref Unsafe.AsRef<IntPtr>(param1);
                    MediaAttributes attributesRef;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetOutputStreamAttributes(dwOutputStreamID, out attributesRef);
                    attributesRef_ = SharpDX.CppObject.ToCallbackPtr<MediaAttributes>(attributesRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int DeleteInputStreamDelegate(IntPtr thisObject, int arg0);
            private static unsafe int DeleteInputStream(IntPtr thisObject, int param0)
            {
                try
                {
                    Result result = default(Result);
                    int dwStreamID = default(int);
                    dwStreamID = (int)param0;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.DeleteInputStream(dwStreamID);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int AddInputStreamsDelegate(IntPtr thisObject, int arg0, void* arg1);
            private static unsafe int AddInputStreams(IntPtr thisObject, int param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    int cStreams = default(int);
                    cStreams = (int)param0;
                    int adwStreamIDs = Unsafe.AsRef<int>(param1);
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.AddInputStreams(cStreams, adwStreamIDs);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetInputAvailableTypeDelegate(IntPtr thisObject, int arg0, int arg1, void* arg2);
            private static unsafe int GetInputAvailableType(IntPtr thisObject, int param0, int param1, void* param2)
            {
                try
                {
                    Result result = default(Result);
                    int dwInputStreamID = default(int);
                    dwInputStreamID = (int)param0;
                    int dwTypeIndex = default(int);
                    dwTypeIndex = (int)param1;
                    ref IntPtr typeOut_ = ref Unsafe.AsRef<IntPtr>(param2);
                    MediaType typeOut;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetInputAvailableType(dwInputStreamID, dwTypeIndex, out typeOut);
                    typeOut_ = SharpDX.CppObject.ToCallbackPtr<MediaType>(typeOut);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetOutputAvailableTypeDelegate(IntPtr thisObject, int arg0, int arg1, void* arg2);
            private static unsafe int GetOutputAvailableType(IntPtr thisObject, int param0, int param1, void* param2)
            {
                try
                {
                    Result result = default(Result);
                    int dwOutputStreamID = default(int);
                    dwOutputStreamID = (int)param0;
                    int dwTypeIndex = default(int);
                    dwTypeIndex = (int)param1;
                    ref IntPtr typeOut_ = ref Unsafe.AsRef<IntPtr>(param2);
                    MediaType typeOut;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetOutputAvailableType(dwOutputStreamID, dwTypeIndex, out typeOut);
                    typeOut_ = SharpDX.CppObject.ToCallbackPtr<MediaType>(typeOut);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int SetInputTypeDelegate(IntPtr thisObject, int arg0, void* arg1, int arg2);
            private static unsafe int SetInputType(IntPtr thisObject, int param0, void* param1, int param2)
            {
                try
                {
                    Result result = default(Result);
                    int dwInputStreamID = default(int);
                    dwInputStreamID = (int)param0;
                    MediaType typeRef = default(MediaType);
                    IntPtr typeRef_ = (IntPtr)param1;
                    TransformSetTypeFlags dwFlags = default(TransformSetTypeFlags);
                    dwFlags = (TransformSetTypeFlags)param2;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    if (typeRef_ != IntPtr.Zero)
                        typeRef = new MediaType(typeRef_);
                    else
                        typeRef = null;
                    result = @this.SetInputType(dwInputStreamID, typeRef, dwFlags);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int SetOutputTypeDelegate(IntPtr thisObject, int arg0, void* arg1, int arg2);
            private static unsafe int SetOutputType(IntPtr thisObject, int param0, void* param1, int param2)
            {
                try
                {
                    Result result = default(Result);
                    int dwOutputStreamID = default(int);
                    dwOutputStreamID = (int)param0;
                    MediaType typeRef = default(MediaType);
                    IntPtr typeRef_ = (IntPtr)param1;
                    TransformSetTypeFlags dwFlags = default(TransformSetTypeFlags);
                    dwFlags = (TransformSetTypeFlags)param2;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    if (typeRef_ != IntPtr.Zero)
                        typeRef = new MediaType(typeRef_);
                    else
                        typeRef = null;
                    result = @this.SetOutputType(dwOutputStreamID, typeRef, dwFlags);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetInputCurrentTypeDelegate(IntPtr thisObject, int arg0, void* arg1);
            private static unsafe int GetInputCurrentType(IntPtr thisObject, int param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    int dwInputStreamID = default(int);
                    dwInputStreamID = (int)param0;
                    ref IntPtr typeOut_ = ref Unsafe.AsRef<IntPtr>(param1);
                    MediaType typeOut;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetInputCurrentType(dwInputStreamID, out typeOut);
                    typeOut_ = SharpDX.CppObject.ToCallbackPtr<MediaType>(typeOut);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetOutputCurrentTypeDelegate(IntPtr thisObject, int arg0, void* arg1);
            private static unsafe int GetOutputCurrentType(IntPtr thisObject, int param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    int dwOutputStreamID = default(int);
                    dwOutputStreamID = (int)param0;
                    ref IntPtr typeOut_ = ref Unsafe.AsRef<IntPtr>(param1);
                    MediaType typeOut;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetOutputCurrentType(dwOutputStreamID, out typeOut);
                    typeOut_ = SharpDX.CppObject.ToCallbackPtr<MediaType>(typeOut);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetInputStatusDelegate(IntPtr thisObject, int arg0, void* arg1);
            private static unsafe int GetInputStatus(IntPtr thisObject, int param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    int dwInputStreamID = default(int);
                    dwInputStreamID = (int)param0;
                    ref int dwFlagsRef = ref Unsafe.AsRef<int>(param1);
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetInputStatus(dwInputStreamID, out dwFlagsRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int GetOutputStatusDelegate(IntPtr thisObject, void* arg0);
            private static unsafe int GetOutputStatus(IntPtr thisObject, void* param0)
            {
                try
                {
                    Result result = default(Result);
                    ref int dwFlagsRef = ref Unsafe.AsRef<int>(param0);
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.GetOutputStatus(out dwFlagsRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int SetOutputBoundsDelegate(IntPtr thisObject, long arg0, long arg1);
            private static unsafe int SetOutputBounds(IntPtr thisObject, long param0, long param1)
            {
                try
                {
                    Result result = default(Result);
                    long hnsLowerBound = default(long);
                    hnsLowerBound = (long)param0;
                    long hnsUpperBound = default(long);
                    hnsUpperBound = (long)param1;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.SetOutputBounds(hnsLowerBound, hnsUpperBound);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int ProcessEventDelegate(IntPtr thisObject, int arg0, void* arg1);
            private static unsafe int ProcessEvent(IntPtr thisObject, int param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    int dwInputStreamID = default(int);
                    dwInputStreamID = (int)param0;
                    MediaEvent eventRef = default(MediaEvent);
                    IntPtr eventRef_ = (IntPtr)param1;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    if (eventRef_ != IntPtr.Zero)
                        eventRef = new MediaEvent(eventRef_);
                    else
                        eventRef = null;
                    result = @this.ProcessEvent(dwInputStreamID, eventRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int ProcessMessageDelegate(IntPtr thisObject, int arg0, void* arg1);
            private static unsafe int ProcessMessage(IntPtr thisObject, int param0, void* param1)
            {
                try
                {
                    Result result = default(Result);
                    TransformMessageType eMessage = default(TransformMessageType);
                    eMessage = (TransformMessageType)param0;
                    IntPtr ulParam = default(IntPtr);
                    ulParam = (IntPtr)param1;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    result = @this.ProcessMessage(eMessage, ulParam);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int ProcessInputDelegate(IntPtr thisObject, int arg0, void* arg1, int arg2);
            private static unsafe int ProcessInput(IntPtr thisObject, int param0, void* param1, int param2)
            {
                try
                {
                    Result result = default(Result);
                    int dwInputStreamID = default(int);
                    dwInputStreamID = (int)param0;
                    Sample sampleRef = default(Sample);
                    IntPtr sampleRef_ = (IntPtr)param1;
                    int dwFlags = default(int);
                    dwFlags = (int)param2;
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    if (sampleRef_ != IntPtr.Zero)
                        sampleRef = new Sample(sampleRef_);
                    else
                        sampleRef = null;
                    result = @this.ProcessInput(dwInputStreamID, sampleRef, dwFlags);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int ProcessOutputDelegate(IntPtr thisObject, int arg0, int arg1, void* arg2, void* arg3);
            private static unsafe int ProcessOutput(IntPtr thisObject, int param0, int param1, void* param2, void* param3)
            {
                try
                {
                    Result result = default(Result);
                    TransformProcessOutputFlags dwFlags = default(TransformProcessOutputFlags);
                    dwFlags = (TransformProcessOutputFlags)param0;
                    int cOutputBufferCount = default(int);
                    cOutputBufferCount = (int)param1;
                    ref TransformOutputDataBuffer.__Native outputSamplesRef_ = Unsafe.AsRef<TransformOutputDataBuffer.__Native>(param2);
                    TransformOutputDataBuffer outputSamplesRef;
                    ref TransformProcessOutputStatus dwStatusRef = ref Unsafe.AsRef<TransformProcessOutputStatus>(param3);
                    ITransform @this = (ITransform)ToShadow<TransformShadow>(thisObject).Callback;
                    outputSamplesRef.__MarshalFrom(ref outputSamplesRef_);
                    result = @this.ProcessOutput(dwFlags, cOutputBufferCount, ref outputSamplesRef, out dwStatusRef);
                    return result;
                }
                catch (Exception exception)
                {
                    return Result.GetResultFromException(exception).Code;
                }
            }
        }

        protected override CppObjectVtbl GetVtbl
        {
            get { return Vtbl; }
        }
    }
}
