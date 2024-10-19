extends CharacterBody2D
@onready var animation = $AnimationPlayer
@onready var jumpSound = preload("res://Scenes/mainGame/Sounds/jump.wav");

const SPEED = 150.0
const JUMP_VELOCITY = -400.0
@export var direction = 0; 

func _physics_process(delta: float) -> void:
	# Add the gravity.
		# the player gets snagged on a triangle tile. fix in the future. it prevents jumping.
	
	#if Input.is_action_just_pressed("up") and is_on_floor():
		#velocity.y = JUMP_VELOCITY;
		#$AudioStreamPlayer2D.stream = jumpSound;
		#$AudioStreamPlayer2D.play();

	direction = Input.get_axis("left", "right")		
	
	if direction:
		velocity.x = direction * SPEED;
		if Input.is_key_pressed(KEY_SPACE):
			animation.play("run");
			velocity.x *= 3;
		else:
			animation.play("walk");
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		animation.play("idle")
		
	if not is_on_floor():
		velocity += get_gravity() * delta;
	else:
		velocity.y = -20;

	move_and_slide()


func _process(_delta: float) -> void: 
	if direction == 1:
		$Player.flip_h = false;
	elif direction == -1:
		$Player.flip_h = true;
