extends Sprite2D

@onready var player = get_node("../CharacterBody2D")
@export var interactable = false
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.
# Called every frame. 'delta' is the elapsed time since the previous frame.

func wait(seconds: float) -> void:
	await get_tree().create_timer(seconds).timeout

func _process(_delta: float) -> void:
	interactable = abs(position.x - player.position.x) < 60
	if interactable:
		self_modulate = Color(1,1,0.6,1)
		if Input.is_action_just_pressed("interact"):
			$Label.visible = true

	else:
		self_modulate = Color(1,1,1,1)
