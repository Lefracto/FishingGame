using System.Collections.Generic;
using Core;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
  [SerializeField] private int _initialBalance = 100;
  [SerializeField] private SatiationMechanism _satiationMechanism;
  
  
  [SerializeField]  private TextAsset _foodCosts;
  [SerializeField]  private List<FoodItem> _sellPositions;


  public override void InstallBindings()
  {
    // Wallet initialising
    Container.Bind<int>().FromInstance(_initialBalance).WhenInjectedInto<Wallet>();
    Container.Bind<Wallet>().AsSingle().NonLazy();

    Container.Bind<List<FoodItem>>().FromInstance(_sellPositions).AsSingle();
    
    // FoodShop initialising
    Container.Bind<TextAsset>().FromInstance(_foodCosts).WhenInjectedInto<CostsContainer>();
    Container.Bind<CostsContainer>().AsSingle().NonLazy();
    Container.Bind<FoodShop>().AsSingle().NonLazy();

    Container.Bind<SatiationMechanism>().FromInstance(_satiationMechanism).AsSingle();
    Container.Bind<FoodInventory>().AsSingle().NonLazy();

    Container.Bind<FishSeller>().AsSingle().NonLazy();

    Container.Bind<FishInventory>().AsSingle().NonLazy();

  }
}