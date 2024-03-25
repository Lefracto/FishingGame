using System.Collections.Generic;
using Core;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
  [SerializeField] private List<FoodItem> _sellFoodPositions;
  [SerializeField] private List<TackleModel> _sellTacklePositions;

  [Space(20)] [SerializeField] private TextAsset _foodCosts;
  [SerializeField] private TextAsset _tackleCosts;


  public override void InstallBindings()
  {
    Container.Bind<Wallet>().AsSingle().NonLazy();
    Container.Bind<FishInventory>().AsSingle().NonLazy();

    Container.Bind<int>().FromInstance(3).WhenInjectedInto<SatiationMechanism>();
    Container.Bind<SatiationMechanism>().AsSingle().NonLazy();

    Container.Bind<FoodInventory>().AsSingle().NonLazy();
    
    Container.Bind<CostsContainer>().FromInstance(new CostsContainer(_foodCosts)).WhenInjectedInto<FoodShop>();
    Container.Bind<CostsContainer>().FromInstance(new CostsContainer(_tackleCosts)).WhenInjectedInto<TackleShop>();

    Container.Bind<List<FoodItem>>().FromInstance(_sellFoodPositions).WhenInjectedInto<FoodShop>();
    Container.Bind<List<TackleModel>>().FromInstance(_sellTacklePositions).WhenInjectedInto<TackleShop>();

    
    Container.Bind<FoodShop>().AsSingle().NonLazy();
    Container.Bind<FishSeller>().AsSingle().NonLazy();
    Container.Bind<TackleInventory>().AsSingle().NonLazy();
    Container.Bind<TackleShop>().AsSingle().NonLazy();

    // Savable data injection
    Container.Bind<ISavable>().To<Wallet>().FromResolve();
    Container.Bind<ISavable>().To<FoodShop>().FromResolve();
  }
}