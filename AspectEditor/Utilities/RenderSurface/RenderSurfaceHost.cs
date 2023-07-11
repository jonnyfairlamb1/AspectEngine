﻿using AspectEditor.DLLWrappers;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace AspectEditor.Utilities {

    public class RenderSurfaceHost : HwndHost {
        private readonly int VK_LBUTTON = 0x01;
        private int _width = 800;
        private int _height = 600;
        private IntPtr _renderWindowHandle = IntPtr.Zero;
        private DelayEventTimer _resizeTimer;

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public int SurfaceId { get; private set; } = ID.INVALID_ID;

        public RenderSurfaceHost(double width, double height) {
            _width = (int)width;
            _height = (int)height;
            _resizeTimer = new(TimeSpan.FromMilliseconds(250));
            _resizeTimer.Triggered += Resize;
            SizeChanged += (s, e) => _resizeTimer.Trigger();
        }

        private void Resize(object? sender, DelayEventTimerArgs e) {
            e.RepeatEvent = GetAsyncKeyState(VK_LBUTTON) < 0;
            if (!e.RepeatEvent) {
                EngineAPI.ResizeRenderSurface(SurfaceId);
            }
        }

        protected override HandleRef BuildWindowCore(HandleRef hwndParent) {
            SurfaceId = EngineAPI.CreateRenderSurface(hwndParent.Handle, _width, _height);
            Debug.Assert(ID.IsValid(SurfaceId));
            _renderWindowHandle = EngineAPI.GetWindowHandle(SurfaceId);
            Debug.Assert(_renderWindowHandle != IntPtr.Zero);

            return new HandleRef(this, _renderWindowHandle);
        }

        protected override void DestroyWindowCore(HandleRef hwnd) {
            EngineAPI.RemoveRenderSurface(SurfaceId);
            SurfaceId = ID.INVALID_ID;
            _renderWindowHandle = IntPtr.Zero;
        }
    }
}