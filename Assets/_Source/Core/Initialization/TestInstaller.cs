using System.Collections.Generic;
using Core;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
  [SerializeField] private List<FoodItem> _sellPositions;
  [Space(20)] [SerializeField] private TextAsset _foodCosts;

  public override void InstallBindings()
  {
    Container.Bind<Wallet>().AsSingle().NonLazy();
    Container.Bind<FishInventory>().AsSingle().NonLazy();
    
    Container.Bind<int>().FromInstance(3).WhenInjectedInto<SatiationMechanism>();
    Container.Bind<SatiationMechanism>().AsSingle().NonLazy();
    
    Container.Bind<FoodInventory>().AsSingle().NonLazy();
    Container.Bind<CostsContainer>().FromInstance(new CostsContainer(_foodCosts)).WhenInjectedInto<FoodShop>();
    Container.Bind<List<FoodItem>>().FromInstance(_sellPositions).WhenInjectedInto<FoodShop>();

    Container.Bind<FoodShop>().AsSingle().NonLazy();
    Container.Bind<FishSeller>().AsSingle().NonLazy();
    
    // Savable data injection
    Container.Bind<ISavable>().To<Wallet>().FromResolve();
    Container.Bind<ISavable>().To<FoodShop>().FromResolve();
    
  }
}