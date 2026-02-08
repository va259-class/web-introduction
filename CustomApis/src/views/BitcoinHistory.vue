<template>
  <h1>Bitcoin Fiyat Geçmişi</h1>
  <div>
    <div class="tab">
      <ul class="tab-menu">
        <li @click="() => selectTab('table')">Tablo Görünümü</li>
        <li @click="() => selectTab('chart')">Grafik Görünümü</li>
      </ul>
      <div v-if="selectedTab == 'table'" class="tab-content">
        <table>
          <thead>
            <tr>
              <th>Tarih</th>
              <th>Fiyat</th>
              <th>Hacim</th>
              <th>Başlangıç</th>
              <th>Bitiş</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="d in historyData">
              <td>{{ d.Date }}</td>
              <td>{{ d.Price }}</td>
              <td>{{ d.Volume }}</td>
              <td>{{ d.Open }}</td>
              <td>{{ d.High }}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <div v-if="selectedTab == 'chart'" class="tab-content">
        <Bar id="volumeChart" :options="chartOptions" :data="volumeData" />
      </div>
    </div>
  </div>
</template>

<script>
import { Bar } from 'vue-chartjs'
import {
  Chart as ChartJS,
  Title,
  Tooltip,
  Legend,
  BarElement,
  LineElement,
  PointElement,
  CategoryScale,
  LinearScale,
} from 'chart.js'

ChartJS.register(
  Title,
  Tooltip,
  Legend,
  BarElement,
  LineElement,
  PointElement,
  CategoryScale,
  LinearScale,
)
const TABNAMES = {
  TABLE: 'table',
  CHART: 'chart',
}
export default {
  name: 'BitcoinHistory',
  components: { Bar },
  data() {
    return {
      selectedTab: TABNAMES.TABLE,
      historyData: [],
      chartOptions: {
        responsive: true,
        maintainAspectRatio: false,
        scales: {
          y: {
            type: 'linear',
            position: 'left',
            title: {
              display: true,
              text: 'Hacim',
            },
          },
          y1: {
            type: 'linear',
            position: 'right',
            grid: {
              drawOnChartArea: false,
            },
            title: {
              display: true,
              text: 'Fiyat',
            },
          },
        },
      },
    }
  },
  mounted() {
    fetch('https://api.sampleapis.com/bitcoin/historical_prices')
      .then((response) => response.json())
      .then((content) => {
        this.historyData = content
          .map((item) => {
            const [month, day, year] = item.Date.split('/')

            return {
              ...item,
              _date: new Date(year, month - 1, day), // JS Date
            }
          })
          .sort((a, b) => a._date - b._date)
      })
  },
  methods: {
    selectTab(name) {
      this.selectedTab = name
    },
    parseNumber(value) {
      if (!value) return 0
      const num = parseFloat(value)
      if (value.includes('K')) return num * 1_000
      if (value.includes('M')) return num * 1_000_000
      return num
    },
  },
  computed: {
    volumeData() {
      return {
        labels: this.historyData.map((b) => b.Date),
        datasets: [
          // 📊 BAR → Volume
          {
            type: 'bar',
            label: 'Hacim',
            backgroundColor: 'rgba(66, 184, 131, 0.5)',
            data: this.historyData.map((b) => this.parseNumber(b.Volume)),
            yAxisID: 'y',
          },

          // 📈 LINE → Price
          {
            type: 'line',
            label: 'Fiyat',
            borderColor: '#ff6384',
            backgroundColor: '#ff6384',
            data: this.historyData.map((b) => b.Price),
            tension: 0.3,
            pointRadius: 0,
            yAxisID: 'y1',
          },
        ],
      }
    },
  },
}
</script>
<style scoped>
.tab .tab-menu {
  display: flex;
  list-style: none;
  margin: 0px;
  padding: 0px;
}

.tab-menu li {
  margin-right: 10px;
  border: 2px solid #42b883;
  color: #42b883;
  border-radius: 5px 5px 0px 0px;
  padding: 5px;
  cursor: pointer;
}
.tab-menu li:hover {
  background-color: #42b883;
  color: #ffffff;
}

.tab table {
  width: 100%;
  border-collapse: collapse;
  margin: 5px;
}

.tab thead th {
  position: sticky;
  top: 0px;
  background: #ffffff;
  z-index: 1;
  text-align: left;
  border-bottom: 1px solid #ccc;
}

.tab-content {
  border: 1px solid #42b883;
  margin-top: 10px;
  height: 400px;
  overflow: hidden;
  overflow-y: scroll;
  width: 100%;
}
#volume-chart {
  width: 100% !important;
  height: 100% !important;
}
</style>
