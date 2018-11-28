from django.contrib import admin

from .models import *
# Register your models here.
admin.site.register(Person)
admin.site.register(Enemy)
admin.site.register(Weapon)
admin.site.register(Mineral)
admin.site.register(Armor)
admin.site.register(Enemy_type)
admin.site.register(Mineral_type)

