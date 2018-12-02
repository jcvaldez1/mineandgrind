from django.db import models

# Create your models here.
from django.core.validators import MinValueValidator,MaxValueValidator

# Create your models here.
class Person(models.Model):
	name = models.CharField(max_length=32)
	level = models.IntegerField(validators=[MinValueValidator(0)])
	health = models.IntegerField(validators=[MinValueValidator(0)])
	def __str__(self):
		return self.name

class Mineral_type(models.Model):
	the_class = models.CharField(max_length=25)
	def __str__(self):
		return self.the_class

class Armor(models.Model):
	damage_reduction = models.FloatField(validators=[MinValueValidator(0),MaxValueValidator(1)])
	amount_modifier = models.ForeignKey(Mineral_type,on_delete=models.CASCADE)
	person_id = models.ForeignKey(Person, on_delete=models.CASCADE)
	def __str__(self):
		return str(self.person_id)

class Weapon(models.Model):
	damage = models.IntegerField()
	durability = models.IntegerField(validators=[MinValueValidator(0)])
	person_id = models.ForeignKey(Person, on_delete=models.CASCADE)
	mineral_type = models.ForeignKey(Mineral_type,on_delete=models.CASCADE)
	def __str__(self):
		return str(self.person_id)

class Mineral(models.Model):
	name = models.CharField(max_length=25)
	mineral_class = models.ForeignKey(Mineral_type, on_delete=models.CASCADE)
	rarity = models.IntegerField(validators=[MaxValueValidator(8)])
	#location = models.ForeignKey
	location_x = models.FloatField()
	location_y = models.FloatField()
	person_id = models.ForeignKey(Person, null=True,on_delete=models.SET_NULL, related_name='owner', default=None)
	world_id = models.ForeignKey(Person, on_delete=models.CASCADE, related_name='existence')
	# add world_id -> which is technically person id this element is assigned to
	def __str__(self):
		return self.name + "-" + str(self.world_id) + "- x:" + str(self.location_x) + "- y:" + str(self.location_y)

class Enemy_type(models.Model):
	the_class = models.CharField(max_length=25)
	def __str__(self):
		return self.the_class


class Enemy(models.Model):
	damage = models.IntegerField()
	health = models.IntegerField()
	location_x = models.FloatField()
	location_y = models.FloatField()
	world_id = models.ForeignKey(Person, on_delete=models.CASCADE)
	enemy_class = models.ForeignKey(Enemy_type,null=True,on_delete=models.SET_NULL)
	def __str__(self):
		return str(self.enemy_class) + "-" + str(self.world_id) + "- x:" + str(self.location_x) + "- y:" + str(self.location_y)

class Paired(models.Model):
	armor_id = models.ForeignKey(Armor,null=True,on_delete=models.SET_NULL)
	weapon_id = models.ForeignKey(Weapon,null=True,on_delete=models.SET_NULL)

class Fight(models.Model):
	enemy_id = models.ForeignKey(Enemy,null=True,on_delete=models.SET_NULL)
	person_id = models.ForeignKey(Person, on_delete=models.CASCADE)

class Equip(models.Model):
	person_id = models.ForeignKey(Person, on_delete=models.CASCADE)
	gear = models.ForeignKey(Paired, on_delete=models.CASCADE)