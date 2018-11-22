from django.shortcuts import render

# Create your views here.
from django.http import HttpResponse, JsonResponse
from .models import Person
from django.core import serializers
def CRUDDER(request, id):
     response = dict()
     if request.method == 'GET':
          response = serializers.serialize('json', Person.objects.filter(pk=id).only('pk'))
     elif request.method == 'DELETE':
          response = serializers.serialize('json', Person.objects.filter(pk=id).only('pk'))
          Person.objects.filter(pk=id).delete() 
     elif request.method == 'PUT':
          params = json.loads(request.body)[0]["fields"]
          newBoy = Person.objects.filter(pk=id)
          newBoy.level = params["level"]
          newBoy.health = params["health"]
          response = serializers.serialize('json', Person.objects.filter(pk=id).only('pk'))
     return JsonResponse(response, safe=False)

def new(request):
     received_json_data=json.loads(request.body)
     if request.method == 'POST':
          temp = Person.objects.create(**received_json_data)
          response = serializers.serialize('json', temp.only('pk'))
          #push_this = Person.objects.new()
          ##push_this = 
          #push_this.save()
    
     return JsonResponse(response, safe=False)
