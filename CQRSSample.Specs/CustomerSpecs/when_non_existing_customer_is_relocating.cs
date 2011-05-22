﻿using System;
using System.Collections.Generic;
using CQRSSample.Commands;
using CQRSSample.Domain.CommandHandlers;
using CQRSSample.Domain.Domain;
using CQRSSample.Domain.Events;
using NUnit.Framework;

namespace CQRSSample.Specs.CustomerSpecs
{
	public class when_non_existing_customer_is_relocating :
		CommandTestFixture<RelocateCustomerCommand, RelocatingCustomerCommandHandler, Customer>
	{
		private Guid _ARId = Guid.NewGuid();

		protected override IEnumerable<DomainEvent> Given()
		{
			yield return new CustomerCreatedEvent(_ARId, "Name", "street", "30", "355 55", "Stockholm", "03985829");
		}

		protected override RelocateCustomerCommand When()
		{
			return new RelocateCustomerCommand(_ARId, "Ringstraße", "1a", "1010", "Wien");
		}

		[Test]
		public void should_throw_non_existing_customer_event()
		{
			Assert.IsInstanceOfType(typeof (NonExistingCustomerException), CaughtException);
		}
	}
}