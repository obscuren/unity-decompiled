﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.LayoutElement
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2216A18B-AF52-44A5-85A0-A1CAA19C1090
// Assembly location: C:\Users\Blake\sandbox\unity\test-project\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>Add this component to a GameObject to make it into a layout element or override values on an existing layout element.</para>
  /// </summary>
  [ExecuteInEditMode]
  [AddComponentMenu("Layout/Layout Element", 140)]
  [RequireComponent(typeof (RectTransform))]
  public class LayoutElement : UIBehaviour, ILayoutElement, ILayoutIgnorer
  {
    [SerializeField]
    private float m_MinWidth = -1f;
    [SerializeField]
    private float m_MinHeight = -1f;
    [SerializeField]
    private float m_PreferredWidth = -1f;
    [SerializeField]
    private float m_PreferredHeight = -1f;
    [SerializeField]
    private float m_FlexibleWidth = -1f;
    [SerializeField]
    private float m_FlexibleHeight = -1f;
    [SerializeField]
    private bool m_IgnoreLayout;

    /// <summary>
    ///   <para>Should this RectTransform be ignored by the layout system?</para>
    /// </summary>
    public virtual bool ignoreLayout
    {
      get
      {
        return this.m_IgnoreLayout;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<bool>(ref this.m_IgnoreLayout, value))
          return;
        this.SetDirty();
      }
    }

    /// <summary>
    ///   <para>The minimum width this layout element may be allocated.</para>
    /// </summary>
    public virtual float minWidth
    {
      get
      {
        return this.m_MinWidth;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<float>(ref this.m_MinWidth, value))
          return;
        this.SetDirty();
      }
    }

    /// <summary>
    ///   <para>The minimum height this layout element may be allocated.</para>
    /// </summary>
    public virtual float minHeight
    {
      get
      {
        return this.m_MinHeight;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<float>(ref this.m_MinHeight, value))
          return;
        this.SetDirty();
      }
    }

    /// <summary>
    ///   <para>The preferred width this layout element should be allocated if there is sufficient space.</para>
    /// </summary>
    public virtual float preferredWidth
    {
      get
      {
        return this.m_PreferredWidth;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<float>(ref this.m_PreferredWidth, value))
          return;
        this.SetDirty();
      }
    }

    /// <summary>
    ///   <para>The preferred height this layout element should be allocated if there is sufficient space.</para>
    /// </summary>
    public virtual float preferredHeight
    {
      get
      {
        return this.m_PreferredHeight;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<float>(ref this.m_PreferredHeight, value))
          return;
        this.SetDirty();
      }
    }

    /// <summary>
    ///   <para>The extra relative width this layout element should be allocated if there is additional available space.</para>
    /// </summary>
    public virtual float flexibleWidth
    {
      get
      {
        return this.m_FlexibleWidth;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<float>(ref this.m_FlexibleWidth, value))
          return;
        this.SetDirty();
      }
    }

    /// <summary>
    ///   <para>The extra relative height this layout element should be allocated if there is additional available space.</para>
    /// </summary>
    public virtual float flexibleHeight
    {
      get
      {
        return this.m_FlexibleHeight;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<float>(ref this.m_FlexibleHeight, value))
          return;
        this.SetDirty();
      }
    }

    /// <summary>
    ///   <para>Called by the layout system.</para>
    /// </summary>
    public virtual int layoutPriority
    {
      get
      {
        return 1;
      }
    }

    protected LayoutElement()
    {
    }

    /// <summary>
    ///   <para>Called by the layout system.</para>
    /// </summary>
    public virtual void CalculateLayoutInputHorizontal()
    {
    }

    /// <summary>
    ///   <para>Called by the layout system.</para>
    /// </summary>
    public virtual void CalculateLayoutInputVertical()
    {
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      this.SetDirty();
    }

    protected override void OnTransformParentChanged()
    {
      this.SetDirty();
    }

    /// <summary>
    ///   <para>See MonoBehaviour.OnDisable.</para>
    /// </summary>
    protected override void OnDisable()
    {
      this.SetDirty();
      base.OnDisable();
    }

    protected override void OnDidApplyAnimationProperties()
    {
      this.SetDirty();
    }

    protected override void OnBeforeTransformParentChanged()
    {
      this.SetDirty();
    }

    /// <summary>
    ///   <para>Mark the LayoutElement as dirty.</para>
    /// </summary>
    protected void SetDirty()
    {
      if (!this.IsActive())
        return;
      LayoutRebuilder.MarkLayoutForRebuild(this.transform as RectTransform);
    }

    protected override void OnValidate()
    {
      this.SetDirty();
    }
  }
}
