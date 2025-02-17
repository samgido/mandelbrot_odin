package main

import "core:fmt"
import rl "vendor:raylib"

W_WIDTH :: 800
W_HEIGHT :: 800

main :: proc() {
	rl.InitWindow(W_WIDTH, W_HEIGHT, "Mandel")
	defer rl.CloseWindow()

	shader := rl.LoadShader("src/shader.vs", "src/shader.fs")
	defer rl.UnloadShader(shader)

	screenResolutionLocation := rl.GetShaderLocation(shader, "screenResolution")

	for !rl.WindowShouldClose() {
		rl.BeginDrawing()
		rl.ClearBackground(rl.GRAY)
		defer rl.EndDrawing()

		rl.SetShaderValue(
			shader,
			screenResolutionLocation,
			&rl.Vector2{f32(W_WIDTH), f32(W_HEIGHT)},
			rl.ShaderUniformDataType.VEC2,
		)

		rl.BeginShaderMode(shader)
		rl.DrawRectangle(0, 0, W_WIDTH, W_HEIGHT, rl.PURPLE)
		rl.EndShaderMode()
	}
}
