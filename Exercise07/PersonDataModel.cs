using System;
using System.Collections;

namespace Labs
{

	public delegate void PersonModelChangedEventHandler(object sender, PersonDataModelChangedEventArgs e);
	
	public class PersonDataModel
	{
		public  event PersonModelChangedEventHandler PersonModelChanged;

		private static ArrayList ALL_PERSONS;
		private static PersonDataModel PERSON_DATA_MODEL;

		public PersonDataModel()
		{
			ALL_PERSONS=new ArrayList();
			PERSON_DATA_MODEL=this;
		}

		public static PersonDataModel getDataModel()
		{
			return PERSON_DATA_MODEL;
		}

		public ArrayList getAllPersons()
		{
			return ALL_PERSONS;
		}

		public void addNewPerson(Person newPerson)
		{
			ALL_PERSONS.Add(newPerson);
			PersonDataModelChangedEventArgs e = new PersonDataModelChangedEventArgs(newPerson, true,false);
			OnPersonModelChanged(e);			
		}

		public void removeFromModel(Person p)
		{
			ALL_PERSONS.Remove(p);
			PersonDataModelChangedEventArgs e = new PersonDataModelChangedEventArgs(p, false,true);
			OnPersonModelChanged(e);
		}
		
	
		private void OnPersonModelChanged(PersonDataModelChangedEventArgs e)
		{
			if (PersonModelChanged != null)
			{
				PersonModelChanged(this, e);
			}
		}
	}

	public class PersonDataModelChangedEventArgs : EventArgs
	{
		private Person _person;
		private bool _isAdded;
		private bool _isRemoved;

		public PersonDataModelChangedEventArgs(Person p, bool added, bool removed)
		{
			_person=p;
			_isAdded=added;
			_isRemoved=removed;
		}

		public Person PersonInChange
		{
			get
			{
				return _person;
			}
		}

		public bool IsAdded
		{
			get
			{
				return _isAdded;
			}
		}	

		public bool IsRemoved
		{
			get
			{
				return _isRemoved;
			}
		}

	}
}
