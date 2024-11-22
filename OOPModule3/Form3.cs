using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPModule3
{
    public partial class Form3 : Form
    {
        private List<Pokemon> pokemons;
        public Form3()
        {
            InitializeComponent();
            InitializePokemons();
            LoadData();
        }
        private void InitializePokemons()
        {
            pokemons = new List<Pokemon>
            {
                new Pokemon { Id = 1, Name = "Pikachu", Type = "Electric", Power = 500, Region = "Kanto" },
                new Pokemon { Id = 2, Name = "Charmander", Type = "Fire", Power = 450, Region = "Kanto" },
                new Pokemon { Id = 3, Name = "Bulbasaur", Type = "Grass", Power = 400, Region = "Kanto" },
                new Pokemon { Id = 4, Name = "Squirtle", Type = "Water", Power = 420, Region = "Kanto" },
                new Pokemon { Id = 5, Name = "Jigglypuff", Type = "Fairy", Power = 390, Region = "Kanto" },
                new Pokemon { Id = 6, Name = "Gengar", Type = "Ghost", Power = 550, Region = "Johto" },
                new Pokemon { Id = 7, Name = "Lucario", Type = "Fighting", Power = 600, Region = "Sinnoh" }
            };
        }

        private void LoadData()
        {
            dataGridView1.DataSource = pokemons;
            comboBox1.Items.AddRange(pokemons.Select(p => p.Type).Distinct().ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedType = comboBox1.SelectedItem.ToString();
            var filteredPokemons = pokemons.Where(p => p.Type == selectedType).ToList();
            dataGridView1.DataSource = filteredPokemons;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int minPower))
            {
                var powerfulPokemons = pokemons.Where(p => p.Power > minPower).ToList();
                listBox1.DataSource = powerfulPokemons.Select(p => $"{p.Name} ({p.Power})").ToList();
            }
            else
            {
                MessageBox.Show("Введите корректное число!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var grouped = pokemons.GroupBy(p => p.Region)
                                  .Select(g => $"{g.Key}: {string.Join(", ", g.Select(p => p.Name))}")
                                  .ToList();
            listBox1.DataSource = grouped;

        }
    }
}
