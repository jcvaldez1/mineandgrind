from django.urls import path,include
from . import views,person
from rest_framework import routers


router = routers.DefaultRouter()
router.register('person', views.PersonView)
router.register('armor', views.ArmorView)
router.register('enemy', views.EnemyView)
router.register('mineral', views.MineralView)
router.register('weapon', views.WeaponView)
router.register('paired', views.PairedView)
router.register('fight', views.FightView)
router.register('equip', views.EquipView)
router.register('mineral_type', views.MineralTypeView)
router.register('enemy_type', views.EnemyTypeView)

urlpatterns = [
     #path('',views.index, name='index'),
     path('', include(router.urls)),
     #path('person/<int:id>/',person.CRUDDER, name='person_CRUDDER'),
     #path('person/',person.new, name='person_new'),
]
