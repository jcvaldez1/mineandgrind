from rest_framework import serializers
from .models import *

class PersonSerializer(serializers.ModelSerializer):
      class Meta:
            model = Person
            fields = ('id' , 'level', 'health')

class MineralSerializer(serializers.ModelSerializer):
      class Meta:
            model = Mineral
            fields = ('id' , 'name', 'mineral_class', 'rarity', 'person_id')

class WeaponSerializer(serializers.ModelSerializer):
      class Meta:
            model = Weapon
            fields = ('id' , 'damage', 'durability', 'person_id')

class ArmorSerializer(serializers.ModelSerializer):
      class Meta:
            model = Armor
            fields = ('id' , 'damage_reduction', 'amount_modifier' , 'person_id')

class EnemySerializer(serializers.ModelSerializer):
      class Meta:
            model = Enemy
            fields = ('id' , 'damage', 'health', 'enemy_class')

class EnemyTypeSerializer(serializers.ModelSerializer):
      class Meta:
            model = Enemy_type
            fields = ('id' , 'the_class')

class MineralTypeSerializer(serializers.ModelSerializer):
      class Meta:
            model = Mineral_type
            fields = ('id' , 'the_class')
