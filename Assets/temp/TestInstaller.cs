using Core;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    [SerializeField] private int _initialBalance = 100;
    [SerializeField] private SatiationMechanism _satiationMechanism;
    
    public override void InstallBindings()
    {
        Container.Bind<int>().FromInstance(_initialBalance).WhenInjectedInto<Wallet>();
        Container.Bind<Wallet>().AsSingle().NonLazy();
        
        Container.Bind<SatiationMechanism>().FromInstance(_satiationMechanism).AsSingle();
        Container.Bind<FoodInventory>().AsSingle().NonLazy();
    }
}