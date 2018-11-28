from rest_framework import serializers
from .models import *

class PersonSerializer(serializers.ModelSerializer):
      class Meta:
            model = Person
            fields = ('name', 'level', 'health')

class MineralSerializer(serializers.ModelSerializer):
      class Meta:
            model = Mineral
            fields = ('id','name', 'mineral_class', 'rarity', 'person_id', 'location_x', 'location_y', 'world_id')

class WeaponSerializer(serializers.ModelSerializer):
      class Meta:
            model = Weapon
            fields = ('damage', 'durability', 'person_id')

class ArmorSerializer(serializers.ModelSerializer):
      class Meta:
            model = Armor
            fields = ('damage_reduction', 'amount_modifier' , 'person_id')

class EnemySerializer(serializers.ModelSerializer):
      class Meta:
            model = Enemy
            fields = ('damage', 'health', 'enemy_class', 'location_x', 'location_y', 'world_id')

class EnemyTypeSerializer(serializers.ModelSerializer):
      class Meta:
            model = Enemy_type
            fields = ['the_class']

class MineralTypeSerializer(serializers.ModelSerializer):
      class Meta:
            model = Mineral_type
            fields = ['the_class']
