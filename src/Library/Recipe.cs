//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"El costo total de la producución es: {GetProductionCost()}");
        }

        /*
        He decidio que esta clase deberia de tener la responsabilidad de obtener el toal del costo de producción ya que esta es la cual contiene toda la información necesaria para realizar dicha tarea. he llegado a esta conclusión siguiendo el principio EXPERT.
        */
        private double GetProductionCost()
        {   
            double totalSupplies = 0;
            double totalEquipment = 0;
            double Total = 0;
            foreach(Step step in this.steps)
            {   
                totalSupplies = totalSupplies + (step.Input.UnitCost*step.Quantity);
                totalEquipment =  totalEquipment + ((step.Equipment.HourlyCost/60)*step.Time);
                Total = totalSupplies+totalEquipment;
            }

            return Total;
        }
    }

}