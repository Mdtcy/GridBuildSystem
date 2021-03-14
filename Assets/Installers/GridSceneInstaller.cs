using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class GridSceneInstaller : MonoInstaller
{
    [SerializeField] 
    private PopupTextController m_popupTextController;
    
    public override void InstallBindings()
    {
        Container.BindInstance(m_popupTextController).AsSingle();
        
    }
}
