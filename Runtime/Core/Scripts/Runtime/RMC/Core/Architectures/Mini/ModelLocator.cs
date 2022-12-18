using System;
using System.Collections.Generic;
using System.Linq;
using RMC.Core.Architectures.MiniMvcs.Model;

namespace RMC.Core.Architectures.MiniMvcs
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class ModelLocator
	{
		private List<IModel> _models;

		public ModelLocator()
		{
			_models = new List<IModel>();
		}

		public void AddModel(IModel baseModel)
		{
			_models.Add(baseModel);
		}

		public T GetModel<T>() where T: IModel
		{
			return _models.OfType<T>().ToList().FirstOrDefault<T>();
		}
		
		public IModel GetModel(Type type)
		{
			return _models.FirstOrDefault(model => model.GetType() == type);
		}

		public void RemoveModel(IModel baseModel)
		{
			_models.Remove(baseModel);
		}
	}
}