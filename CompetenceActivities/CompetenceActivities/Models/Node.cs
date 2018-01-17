using System;

namespace MentoringFramework.Models
{
	public interface Node
	{
		bool isCompleted();
		void setCompletion(bool completion);
		bool isAccessible();
		void setAccessibility(bool accessible);
		String getName();
	}
}

