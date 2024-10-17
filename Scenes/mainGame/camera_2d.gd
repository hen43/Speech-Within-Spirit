extends Camera2D

@onready var player = get_node("../CharacterBody2D")

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	position.x = lerp(position.x, player.position.x, 0.16) # 0.16 controls the smoothness
	position.y = lerp(position.y, player.position.y, 0.16)
	
	if Input.is_key_pressed(KEY_SPACE):
		zoom += (Vector2(1,1) - zoom)/16;
	else:
		zoom += (Vector2(1.2,1.2) - zoom)/16;
