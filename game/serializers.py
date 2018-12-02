from rest_framework import serializers
from .models import *

class PersonSerializer(serializers.ModelSerializer):
      class Meta:
            model = Person
            fields = ('id','name', 'level', 'health')

class MineralSerializer(serializers.ModelSerializer):
      class Meta:
            model = Mineral
            fields = ('id','name', 'mineral_class', 'rarity', 'person_id', 'location_x', 'location_y', 'world_id')

class WeaponSerializer(serializers.ModelSerializer):
      class Meta:
            model = Weapon
            fields = ('id','damage', 'durability', 'person_id', 'mineral_type')

class ArmorSerializer(serializers.ModelSerializer):
      class Meta:
            model = Armor
            fields = ('id','damage_reduction', 'amount_modifier' , 'person_id')

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

class PairedSerializer(serializers.ModelSerializer):
      class Meta:
            model = Paired
            fields = ('armor_id', 'weapon_id')

class FightSerializer(serializers.ModelSerializer):
      class Meta:
            model = Fight
            fields = ('enemy_id', 'person_id')

class EquipSerializer(serializers.ModelSerializer):
      class Meta:
            model = Equip
            fields = ('person_id', 'gear')
