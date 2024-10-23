extends Sprite2D

func _ready():
	visible = true;
	await wait(1.5)  # Waits for 3 seconds
	visible = false;
	
func wait(seconds: float) -> void:
	await get_tree().create_timer(seconds).timeout
