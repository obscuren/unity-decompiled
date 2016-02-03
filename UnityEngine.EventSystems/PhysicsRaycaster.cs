using System;
using System.Collections.Generic;

namespace UnityEngine.EventSystems
{
	/// <summary>
	///   <para>Raycaster for casting against 3D Physics components.</para>
	/// </summary>
	[AddComponentMenu("Event/Physics Raycaster"), RequireComponent(typeof(Camera))]
	public class PhysicsRaycaster : BaseRaycaster
	{
		protected const int kNoEventMaskSet = -1;

		protected Camera m_EventCamera;

		[SerializeField]
		protected LayerMask m_EventMask = -1;

		/// <summary>
		///   <para>Get the camera that is used for this module.</para>
		/// </summary>
		public override Camera eventCamera
		{
			get
			{
				if (this.m_EventCamera == null)
				{
					this.m_EventCamera = base.GetComponent<Camera>();
				}
				return this.m_EventCamera ?? Camera.main;
			}
		}

		/// <summary>
		///   <para>Get the depth of the configured camera.</para>
		/// </summary>
		public virtual int depth
		{
			get
			{
				return (!(this.eventCamera != null)) ? 16777215 : ((int)this.eventCamera.depth);
			}
		}

		/// <summary>
		///   <para>Logical and of Camera mask and eventMask.</para>
		/// </summary>
		public int finalEventMask
		{
			get
			{
				return (!(this.eventCamera != null)) ? -1 : (this.eventCamera.cullingMask & this.m_EventMask);
			}
		}

		/// <summary>
		///   <para>Mask of allowed raycast events.</para>
		/// </summary>
		public LayerMask eventMask
		{
			get
			{
				return this.m_EventMask;
			}
			set
			{
				this.m_EventMask = value;
			}
		}

		protected PhysicsRaycaster()
		{
		}

		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			if (this.eventCamera == null)
			{
				return;
			}
			Ray ray = this.eventCamera.ScreenPointToRay(eventData.position);
			float maxDistance = this.eventCamera.farClipPlane - this.eventCamera.nearClipPlane;
			RaycastHit[] array = Physics.RaycastAll(ray, maxDistance, this.finalEventMask);
			if (array.Length > 1)
			{
				Array.Sort<RaycastHit>(array, (RaycastHit r1, RaycastHit r2) => r1.distance.CompareTo(r2.distance));
			}
			if (array.Length != 0)
			{
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					RaycastResult item = new RaycastResult
					{
						gameObject = array[i].collider.gameObject,
						module = this,
						distance = array[i].distance,
						worldPosition = array[i].point,
						worldNormal = array[i].normal,
						screenPosition = eventData.position,
						index = (float)resultAppendList.Count,
						sortingLayer = 0,
						sortingOrder = 0
					};
					resultAppendList.Add(item);
					i++;
				}
			}
		}
	}
}