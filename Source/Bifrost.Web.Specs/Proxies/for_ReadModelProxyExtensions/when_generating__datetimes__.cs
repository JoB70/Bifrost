﻿using Bifrost.CodeGeneration;
using Bifrost.CodeGeneration.JavaScript;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace Bifrost.Web.Specs.Proxies.for_ReadModelProxyExtensions
{
    public class when_generating__datetimes__
    {
        static Container container;
        static Mock<ICodeWriter> writer_mock;

        Establish context = () =>
            {
                container = new FunctionBody();
                writer_mock = new Mock<ICodeWriter>();
            };

        Because of = () => container.WithPropertiesFrom(typeof(ObjectWithDateTime)).Write(writer_mock.Object);

        It should_write_property_name = () =>  writer_mock.Verify(w => w.WriteWithIndentation("this.{0} = ", "dateTimeProperty"));
        It should_write__property_value = () => writer_mock.Verify(w => w.Write("new Date()", Moq.It.IsAny<Object[]>()));

    }
    
}
