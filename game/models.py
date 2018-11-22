from django.db import models

# Create your models here.
from django.core.validators import MinValueValidator,MaxValueValidator

# Create your models here.
class Person(models.Model):
	level = models.IntegerField(validators=[MinValueValidator(0)])
	health = models.IntegerField(validators=[MinValueValidator(0)])

class Mineral_type(models.Model):
	the_class = models.CharField(max_length=25)

class Armor(models.Model):
	damage_reduction = models.FloatField(validators=[MinValueValidator(0),MaxValueValidator(1)])
	amount_modifier = models.ForeignKey(Mineral_type,null=True,on_delete=models.SET_NULL)
	person_id = models.ForeignKey(Person, on_delete=models.CASCADE)

class Weapon(models.Model):
	damage = models.IntegerField()
	durability = models.IntegerField(validators=[MinValueValidator(0)])
	person_id = models.ForeignKey(Person, on_delete=models.CASCADE)

class Mineral(models.Model):
	name = models.CharField(max_length=25)
	mineral_class = models.ForeignKey(Mineral_type, on_delete=models.CASCADE)
	rarity = models.IntegerField(validators=[MaxValueValidator(8)])
	#location = models.ForeignKey
	person_id = models.ForeignKey(Person, on_delete=models.CASCADE)


class Enemy_type(models.Model):
	the_class = models.CharField(max_length=25)

class Enemy(models.Model):
	damage = models.IntegerField()
	health = models.IntegerField()
	enemy_class = models.ForeignKey(Enemy_type,null=True,on_delete=models.SET_NULL)



