from django.shortcuts import render
from rest_framework import viewsets
from .models import *
from .serializers import *
from django_filters.rest_framework import DjangoFilterBackend

# Create your views here.
from django.http import HttpResponse, JsonResponse

class PersonView(viewsets.ModelViewSet):
      queryset = Person.objects.all()
      serializer_class = PersonSerializer
      filter_backends = (DjangoFilterBackend,)
      filter_fields = ['name']

class MineralView(viewsets.ModelViewSet):
      queryset = Mineral.objects.all()
      serializer_class = MineralSerializer
      filter_backends = (DjangoFilterBackend,)
      filter_fields = ['name' , 'person_id', 'world_id']

class MineralTypeView(viewsets.ModelViewSet):
      queryset = Mineral_type.objects.all()
      serializer_class = MineralTypeSerializer
      filter_backends = (DjangoFilterBackend,)
      filter_fields = ['the_class']

class EnemyView(viewsets.ModelViewSet):
      queryset = Enemy.objects.all()
      serializer_class = EnemySerializer
      filter_backends = (DjangoFilterBackend,)
      filter_fields = ['world_id']

class EnemyTypeView(viewsets.ModelViewSet):
      queryset = Enemy_type.objects.all()
      serializer_class = EnemyTypeSerializer
      filter_backends = (DjangoFilterBackend,)
      filter_fields = ['the_class']

class WeaponView(viewsets.ModelViewSet):
      queryset = Weapon.objects.all()
      serializer_class = WeaponSerializer
      filter_backends = (DjangoFilterBackend,)
      filter_fields = ['person_id']

class ArmorView(viewsets.ModelViewSet):
      queryset = Armor.objects.all()
      serializer_class = ArmorSerializer
      filter_backends = (DjangoFilterBackend,)
      filter_fields = ['person_id']

def index(request):
     return HttpResponse("test")
