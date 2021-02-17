using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewPresenterBase<V, M> : AllBase
    where V : ViewBase
    where M : ModelBase
{
    protected M model;
    protected V view;

    protected override void OnAwake()
    {
        base.OnAwake();
        Init();
    }

    private void Init()
    {
        model = (M)GetComponent<ModelBase>();
        view = (V)GetComponent<ViewBase>();
    }
}
