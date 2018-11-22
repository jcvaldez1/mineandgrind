from django.shortcuts import render
from rest_framework import viewsets
from .models import *
from .serializers import *

# Create your views here.
from django.http import HttpResponse, JsonResponse

class PersonView(viewsets.ModelViewSet):
      queryset = Person.objects.all()
      serializer_class = PersonSerializer

class MineralView(viewsets.ModelViewSet):
      queryset = Mineral.objects.all()
      serializer_class = MineralSerializer

class MineralTypeView(viewsets.ModelViewSet):
      queryset = Mineral_type.objects.all()
      serializer_class = MineralTypeSerializer

class EnemyView(viewsets.ModelViewSet):
      queryset = Enemy.objects.all()
      serializer_class = EnemySerializer

class EnemyTypeView(viewsets.ModelViewSet):
      queryset = Enemy_type.objects.all()
      serializer_class = EnemyTypeSerializer

class WeaponView(viewsets.ModelViewSet):
      queryset = Weapon.objects.all()
      serializer_class = WeaponSerializer

class ArmorView(viewsets.ModelViewSet):
      queryset = Armor.objects.all()
      serializer_class = ArmorSerializer

def index(request):
     return HttpResponse("test")
