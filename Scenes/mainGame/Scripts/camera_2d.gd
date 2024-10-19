extends Camera2D

@onready var player = get_node("../Player")
@export var window_size = DisplayServer.window_get_size()

func _ready() -> void:
	pass;

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	position.x = lerp(position.x, player.position.x, 0.16) # 0.16 controls the smoothness
	position.y = lerp(position.y, player.position.y, 0.16)
	
	if Input.is_key_pressed(KEY_SPACE):
		zoom += (Vector2(2,2) - zoom)/16;
		position += Vector2((randf()-0.5) * 4, (randf()-0.5) * 4)
	else:
		zoom += (Vector2(2.6,2.6) - zoom)/16;
