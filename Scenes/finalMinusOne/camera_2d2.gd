extends Camera2D

@onready var player = get_node("../Globber")
@export var window_size = DisplayServer.window_get_size()

func _ready() -> void:
	zoom = Vector2(2.2, 2.2);	
	position.x = player.position.x;
	position.y = player.position.y;
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:	
	zoom = Vector2(2.2, 2.2);	
	position.x = lerp(position.x, player.position.x, 0.16);
	position.y = lerp(position.y, player.position.y, 0.16);
