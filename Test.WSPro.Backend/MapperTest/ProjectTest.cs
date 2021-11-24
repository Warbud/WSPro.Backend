using System;
using System.Collections.Generic;
using System.Linq;
using MapsterMapper;
using NUnit.Framework;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace Test.WSPro.Backend.MapperTest
{
    [TestFixture]
    public class ProjectTest
    {
        public IMapper Mapper;

        [OneTimeSetUp]
        public void Init()
        {
            Mapper = new MapperTestService().Mapper;
        }

        [TestFixture]
        class TestCreateProjectDto:ProjectTest
        {
            public CreateProjectDto Dto;
            public Project Entity;

            [TestFixture]
            class TestRequiredAttributes:TestCreateProjectDto
            {
                [OneTimeSetUp]
                public void CreateData()
                {
                    Dto = new CreateProjectDto("project name", null,null,new List<StatusEnum>() { StatusEnum.InProgress ,StatusEnum.Finished},
                        new List<AppEnum>() { AppEnum.ModelViewer ,AppEnum.WorkProgressGeneral,});

                    Entity = Mapper.Map<Project>(Dto);
                }

                [OneTimeTearDown]
                public void OnCancel()
                {
                    Dto = null;
                    Entity = null;
                }

                [Test]
                public void ShouldMapName()
                {
                    Assert.AreEqual("project name",Entity.Name);
                }

                [Test]
                public void ShouldMapWebconCodeAsNull()
                {
                    Assert.AreEqual(null,Entity.WebconCode);
                }

                [Test]
                public void ShouldMapMethodologyCodeAsNull()
                {
                    Assert.AreEqual(null,Entity.MetodologyCode);
                }

                [Test]
                public void ShouldMapSupportedStatuses()
                {
                    Assert.That(Entity.SupportedStatuses,Is.TypeOf<List<StatusEnum>>());
                    Assert.That(Entity.SupportedStatuses,Is.Not.Empty);
                    Assert.That(Entity.SupportedStatuses.Count(),Is.EqualTo(2));
                }
                [Test]
                public void ShouldMapSupportedModules()
                {
                    Assert.That(Entity.SupportedStatuses,Is.TypeOf<List<AppEnum>>());
                    Assert.That(Entity.SupportedStatuses,Is.Not.Empty);
                    Assert.That(Entity.SupportedStatuses.Count(),Is.EqualTo(2));
                }

                [Test]
                public void ShouldMapCentralScheduleSync()
                {
                    Assert.False(Entity.CentralScheduleSync);
                }
                
            }
            
            [TestFixture]
            class TestAllAttributes:TestCreateProjectDto
            {
                [OneTimeSetUp]
                public void CreateData()
                {
                    Dto = new CreateProjectDto("project name", "webcon","methodology",new List<StatusEnum>() { StatusEnum.Finished},
                        new List<AppEnum>() { AppEnum.ModelViewer ,AppEnum.WorkProgressGeneral,}, true);

                    Entity = Mapper.Map<Project>(Dto);
                }

                [OneTimeTearDown]
                public void OnCancel()
                {
                    Dto = null;
                    Entity = null;
                }

                [Test]
                public void ShouldMapName()
                {
                    Assert.AreEqual("project name",Entity.Name);
                }

                [Test]
                public void ShouldMapWebconCodeAsNull()
                {
                    Assert.AreEqual("webcon",Entity.WebconCode);
                }

                [Test]
                public void ShouldMapMethodologyCodeAsNull()
                {
                    Assert.AreEqual("methodology",Entity.MetodologyCode);
                }

                [Test]
                public void ShouldMapSupportedStatuses()
                {
                    Assert.That(Entity.SupportedStatuses,Is.TypeOf<List<StatusEnum>>());
                    Assert.That(Entity.SupportedStatuses,Is.Not.Empty);
                    Assert.That(Entity.SupportedStatuses.Count,Is.EqualTo(1));
                }
                [Test]
                public void ShouldMapSupportedModules()
                {
                    Assert.That(Entity.SupportedStatuses,Is.TypeOf<List<AppEnum>>());
                    Assert.That(Entity.SupportedStatuses,Is.Not.Empty);
                    Assert.That(Entity.SupportedStatuses.Count(),Is.EqualTo(2));
                }

                [Test]
                public void ShouldMapCentralScheduleSync()
                {
                    Assert.True(Entity.CentralScheduleSync);
                }
                
            }
        }

        [TestFixture]
        class TestUpdateProjectDto:ProjectTest
        {
            public UpdateProjectDto Dto;
            public Project Entity;
            
            [TestFixture]
            class TestEntityContainingNulls:TestUpdateProjectDto
            {
                [SetUp]
                public void OnStart()
                {
                    Entity = new Project()
                    {
                        Id = 1,
                        Name = "test name",
                        MetodologyCode = "code",
                        SupportedStatuses = new List<StatusEnum>() { StatusEnum.InProgress, StatusEnum.Finished },
                        WebconCode = "webcon",
                        CentralScheduleSync = true
                    };
                }

                [TestFixture]
                class TestBaseParams:TestEntityContainingNulls
                {
                    [Test]
                    public void DoNotTouchId()
                    {
                        var oldEntity = Entity.Id;
                        var dto = new UpdateProjectDto(null, null, null, null, null, null);
                        Mapper.Map(dto, Entity);
                        Assert.AreEqual(oldEntity, Entity.Id);
                    }

                    [TestCase(null,"test name")]
                    [TestCase("nowa nazwa","nowa nazwa")]
                    public void ShouldMapName(string passed, string newValue)
                    {
                        var dto = new UpdateProjectDto(passed, null, null, null, null, null);
                        Assert.AreEqual(passed, dto.Name);
                        Mapper.Map(dto, Entity);
                        Assert.AreEqual(newValue, Entity.Name);
                    
                    }

                    [TestCase(null,"webcon")]
                    [TestCase("new webcon","new webcon")]
                    public void ShouldMapWebconCode(string passed, string newValue)
                    {
                        var dto = new UpdateProjectDto(null, passed, null, null, null, null);
                        Assert.AreEqual(passed, dto.WebconCode);
                        Mapper.Map(dto, Entity);
                        Assert.AreEqual(newValue, Entity.WebconCode);
                    
                    }
                    [TestCase(null,"code")]
                    [TestCase("new code","new code")]
                    public void ShouldMapMethodologyCode(string passed, string newValue)
                    {
                        var dto = new UpdateProjectDto(null, null, passed, null, null, null);
                        Assert.AreEqual(passed, dto.MetodologyCode);
                        Mapper.Map(dto, Entity);
                        Assert.AreEqual(newValue, Entity.MetodologyCode);
                    
                    }
                    [TestCase(null,true,true,TestName = "ExpressionTest_1")]
                    [TestCase(false,true,false,TestName = "ExpressionTest_2")]
                    [TestCase(true,true,true,TestName = "ExpressionTest_3")]
                    public void ShouldMapCentralScheduleSync(bool? passed, bool oldValue,bool newValue)
                    {
                        Assert.AreEqual(oldValue,Entity.CentralScheduleSync);
                        var dto = new UpdateProjectDto(null, null, null, null,null, passed);
                        Assert.AreEqual(passed, dto.CentralScheduleSync);
                        Mapper.Map(dto, Entity);
                        Assert.AreEqual(newValue, Entity.CentralScheduleSync);
                    }

                }

                [TestFixture]
                class ShouldMapSuportedStatuses:TestEntityContainingNulls
                {
                    public Project tempEntity;
                    [SetUp]
                    public void RestartData()
                    {
                        tempEntity = new Project()
                        {
                            Id = Entity.Id, Models = Entity.Models, Name = Entity.Name,
                            MetodologyCode = Entity.MetodologyCode, SupportedStatuses = Entity.SupportedStatuses,
                            WebconCode = Entity.WebconCode, CentralScheduleSync = Entity.CentralScheduleSync
                        };
                    }

                    [Test]
                    public void WhileListIsEmpty()
                    {
                        
                        var data = new List<StatusEnum> {  };
                        var dto = new UpdateProjectDto(null, null, null, data, null,null);
                        
                        Assert.IsEmpty(dto.SupportedStatuses);
                        
                        Mapper.Map(dto, tempEntity);
                        
                        Assert.IsEmpty(tempEntity.SupportedStatuses);
                    }
                    
                    [Test]
                    public void WhileListContainsElements()
                    {
                        var data = new List<StatusEnum> { StatusEnum.Finished };
                        var dto = new UpdateProjectDto(null, null, null, data, null,null);
                        
                        Assert.AreEqual(1, dto.SupportedStatuses.Count);
                        Assert.That(dto.SupportedStatuses.Contains(StatusEnum.Finished));
                        
                        Mapper.Map(dto, tempEntity);
                        
                        Assert.AreEqual(1, tempEntity.SupportedStatuses.Count());
                        Assert.That(tempEntity.SupportedStatuses.Contains(StatusEnum.Finished));
                    }
                    
                    [Test]
                    public void WhileListIsNull()
                    {
                        var dto = new UpdateProjectDto(null, null, null, null, null,null);
                        
                        Assert.AreEqual(null, dto.SupportedStatuses);
                        
                        Mapper.Map(dto, tempEntity);
                        
                        Assert.AreEqual(2, tempEntity.SupportedStatuses.Count());
                        Assert.That(tempEntity.SupportedStatuses.Contains(StatusEnum.Finished));
                        Assert.That(tempEntity.SupportedStatuses.Contains(StatusEnum.InProgress));

                    }
                }
            }
        }
    }
}