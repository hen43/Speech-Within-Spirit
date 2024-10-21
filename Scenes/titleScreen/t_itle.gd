extends Label
# Called when the node enters the scene tree for the first time.
func key(x):
	return (Input.is_key_pressed(x));

func _ready() -> void:
	pass # Replace with function body.
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	if key(KEY_SPACE):
		print('Scene changed to \"mainGame\"');
		get_tree().change_scene_to_file("res://Scenes/mainGame/Day1.tscn");

func _on_button_focus_entered() -> void:
	get_tree().change_scene_to_file("res://Scenes/mainGame/Day1.tscn");
