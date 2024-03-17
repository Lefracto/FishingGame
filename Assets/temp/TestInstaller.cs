using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        int initialBalance = 100;
        Container.Bind<int>().FromInstance(initialBalance).WhenInjectedInto<Wallet>();
        Container.Bind<Wallet>().AsSingle().NonLazy();
    }
}