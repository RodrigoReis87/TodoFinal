using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;
        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "Usuário A", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "Usuário A", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "Usuário B", DateTime.Now.AddDays(-20)));
            _items.Add(new TodoItem("Tarefa 4", "Usuário A", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "Usuário B", DateTime.Now.AddDays(+10)));
            _items.Add(new TodoItem("Tarefa 6", "Usuário B", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 7", "Usuário A", DateTime.Now));
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Usuário B"));
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_concluidas()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("Usuário B"));
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_nao_concluidas()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("Usuário B"));
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_da_data_informada()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("Usuário B", DateTime.Now, false));
            Assert.AreEqual(1, result.Count());
        }
    }
}