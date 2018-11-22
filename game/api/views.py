# generic view for testing

from rest_framework import generics

class gameRudView(generics.RetrieveUpdateDestroyAPIView):
      pass
      lookup_field	= 'pk'
