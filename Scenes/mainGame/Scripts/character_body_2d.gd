extends CharacterBody2D
@onready var animation = $AnimationPlayer

const SPEED = 150.0
const JUMP_VELOCITY = -400.0
@export var direction = 0; 

func _physics_process(delta: float) -> void:
	# Add the gravity.
	if not is_on_floor():
		velocity += get_gravity() * delta
		
	# Handle jump.
	if Input.is_action_just_pressed("up") and is_on_floor():
		velocity.y = JUMP_VELOCITY

	direction = Input.get_axis("left", "right")		
	
	if direction:
		velocity.x = direction * SPEED;
		animation.play("walk");
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		animation.play("idle")

	move_and_slide()


func _process(_delta: float) -> void: 
	if direction == 1:
		$Player.flip_h = false;
	elif direction == -1:
		$Player.flip_h = true;
