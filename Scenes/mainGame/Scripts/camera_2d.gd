extends Camera2D

@onready var player = get_node("../Player")
@onready var mainGame = get_node("/root/MainGame")
@export var window_size = DisplayServer.window_get_size()

func _ready() -> void:
	zoom = Vector2(2.6 + (mainGame.ingameDay * 0.3),2.6 + (mainGame.ingameDay * 0.3));	
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	var shake = (int)(mainGame.ingameDay == 4)
	
	zoom = Vector2(2.6 + (mainGame.ingameDay * 0.3),2.6 + (mainGame.ingameDay * 0.3));	
	position.x = lerp(position.x, player.position.x, 0.16) + randf_range(-0.5 * shake, 0.5 * shake)
	position.y = lerp(position.y, player.position.y, 0.16) + randf_range(-0.5 * shake, 0.5 * shake)
