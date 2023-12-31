#pragma comment(lib, "engine.lib")

#define TEST_ENTITY_COMPONENTS 0
#define TEST_WINDOW 1
#if  TEST_ENTITY_COMPONENTS
#include "TestEntityComponents.h"
#elif TEST_WINDOW
#include "TestWindow.h"
#else One of the tests needs to be enabled
#endif //  TEST_ENTITY_COMPONENTS

#ifdef _WIN64
#include <Windows.h>

int WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int) {
#if _DEBUG
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
#endif
	engine_test test{};

	if (test.initialize()) {
		MSG msg{};
		bool is_running{ true };
		while (is_running)
		{
			while (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE)) {
				TranslateMessage(&msg);
				DispatchMessage(&msg);
				is_running &= (msg.message != WM_QUIT);
			}
			test.run();
		}
	}

	test.shutdown();
	return 0;
}

#else
int main() {
#if _DEBUG
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
#endif

	engine_test test{};

	if (test.initialize()) {
		test.run();
	}

	test.shutdown();
}
#endif