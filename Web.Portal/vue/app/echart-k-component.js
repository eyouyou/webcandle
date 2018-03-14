var option = function () {
    return {
        backgroundColor: '#eee',
        animation: false,
        legend: {
            bottom: 10,
            left: 'center',
            data: ['Dow-Jones index', 'MA5', 'MA10', 'MA20', 'MA30']
        },
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'cross'
            },
            backgroundColor: 'rgba(245, 245, 245, 0.8)',
            borderWidth: 1,
            borderColor: '#ccc',
            padding: 10,
            textStyle: {
                color: '#000'
            },
            position: function (pos, params, el, elRect, size) {
                var obj = { top: 10 };
                obj[['left', 'right'][+(pos[0] < size.viewSize[0] / 2)]] = 30;
                return obj;
            },
            extraCssText: 'width: 170px'
        },
        axisPointer: {
            link: { xAxisIndex: 'all' },
            label: {
                backgroundColor: '#777'
            }
        },
        toolbox: {
            feature: {
                dataZoom: {
                    yAxisIndex: false
                },
                brush: {
                    type: ['lineX', 'clear']
                }
            }
        },
        brush: {
            xAxisIndex: 'all',
            brushLink: 'all',
            outOfBrush: {
                colorAlpha: 0.1
            }
        },
        visualMap: {
            seriesIndex: 5,
            dimension: 2,
            pieces: [{
                value: 1,
                color: '#2f4554'
            }, {
                value: -1,
                color: '#c23531'
            }]
        },
        grid: [
            {
                left: '10%',
                right: '8%',
                height: '50%'
            },
            {
                left: '10%',
                right: '8%',
                top: '63%',
                height: '16%'
            }
        ],
        xAxis: [
            {
                type: 'category',
                data: [],
                scale: true,
                boundaryGap: false,
                axisLine: { onZero: false },
                splitLine: { show: false },
                splitNumber: 20,
                min: 'dataMin',
                max: 'dataMax',
                axisPointer: {
                    z: 100
                }
            },
            {
                type: 'category',
                gridIndex: 1,
                data: [],
                scale: true,
                boundaryGap: false,
                axisLine: { onZero: false },
                axisTick: { show: false },
                splitLine: { show: false },
                axisLabel: { show: false },
                splitNumber: 20,
                min: 'dataMin',
                max: 'dataMax',
                axisPointer: {
                    label: {
                        formatter: function (params) {
                            var seriesValue = (params.seriesData[0] || {}).value;
                            return params.value
                            + (seriesValue != null
                                ? '\n' + echarts.format.addCommas(seriesValue)
                                : ''
                            );
                        }
                    }
                }
            }
        ],
        yAxis: [
            {
                scale: true,
                splitArea: {
                    show: true
                }
            },
            {
                scale: true,
                gridIndex: 1,
                splitNumber: 2,
                axisLabel: { show: false },
                axisLine: { show: false },
                axisTick: { show: false },
                splitLine: { show: false }
            }
        ],
        dataZoom: [
            {
                type: 'inside',
                xAxisIndex: [0, 1],
                start: 98,
                end: 100
            },
            {
                show: true,
                xAxisIndex: [0, 1],
                type: 'slider',
                top: '85%',
                start: 98,
                end: 100
            }
        ],
        series: [
            {
                name: 'Dow-Jones index',
                type: 'candlestick',
                data: [],
                itemStyle: {
                    normal: {
                        borderColor: null,
                        borderColor0: null
                    }
                },
                tooltip: {
                    formatter: function (param) {
                        param = param[0];
                        return [
                            'Date: ' + param.name + '<hr size=1 style="margin: 3px 0">',
                            'Open: ' + param.data[0] + '<br/>',
                            'Close: ' + param.data[1] + '<br/>',
                            'Lowest: ' + param.data[2] + '<br/>',
                            'Highest: ' + param.data[3] + '<br/>'
                        ].join('');
                    }
                }
            },
            {
                name: 'MA5',
                type: 'line',
                data: [],
                smooth: true,
                lineStyle: {
                    normal: { opacity: 0.5 }
                }
            },
            {
                name: 'MA10',
                type: 'line',
                data: [],
                smooth: true,
                lineStyle: {
                    normal: { opacity: 0.5 }
                }
            },
            {
                name: 'MA20',
                type: 'line',
                data: [],
                smooth: true,
                lineStyle: {
                    normal: { opacity: 0.5 }
                }
            },
            {
                name: 'MA30',
                type: 'line',
                data: [],
                smooth: true,
                lineStyle: {
                    normal: { opacity: 0.5 }
                }
            },
            {
                name: 'Volume',
                type: 'bar',
                xAxisIndex: 1,
                yAxisIndex: 1,
                data: []
            }
        ]
    };
};
function splitData(rawData) {
    var categoryData = [];
    var values = [];
    var volumes = [];
    for (var i = 0; i < rawData.length; i++) {
        categoryData.push(rawData[i].splice(0, 1)[0]);
        values.push(rawData[i]);
        volumes.push([i, rawData[i][4], rawData[i][0] > rawData[i][1] ? 1 : -1]);
    }

    return {
        categoryData: categoryData,
        values: values,
        volumes: volumes
    };
}
function calculateMA(dayCount, data) {
    var result = [];
    for (var i = 0, len = data.values.length; i < len; i++) {
        if (i < dayCount) {
            result.push('-');
            continue;
        }
        var sum = 0;
        for (var j = 0; j < dayCount; j++) {
            sum += data.values[i - j][1];
        }
        result.push(+(sum / dayCount).toFixed(3));
    }
    return result;
}
function distribute(data) {
    var recv = new option();
    var tempData = splitData(data);

    recv.xAxis[0].data = tempData.categoryData;
    recv.xAxis[1].data = tempData.categoryData;
    recv.series[0].data = tempData.values;
    recv.series[1].data = calculateMA(5, tempData);//MA5
    recv.series[2].data = calculateMA(10, tempData);//MA10
    recv.series[3].data = calculateMA(20, tempData);//MA20
    recv.series[4].data = calculateMA(30, tempData);//MA30
    recv.series[5].data = tempData.volumes;//Volume
    return recv;
}
Vue.component('echart-k', {
    template:'<div class="echart-k"><slot></slot></div>',
    props: ['code'],
    data: function () {
        return { myChart: {} };
    },
    mounted: function () {
        var vm = this;
        console.log("enter ")
        console.log(vm.code)
        if (vm.code != "") {
            console.log("code init:" + vm.code)
            var xhr = new XMLHttpRequest();
            xhr.open('GET', "/" + vm.code + ".json");
            var $quotation = app.push.hubs[0];
            //console.log(app.currentSecurity.name);
            xhr.onload = function () {
                var Simulatedata = JSON.parse(xhr.responseText);
                console.log(Simulatedata)
                var data = distribute(Simulatedata);
                //console.log(self.newOption);
                vm.myChart.setOption({}, true);
                vm.myChart.setOption(data, true);
                $quotation.client.getData = function (data) {
                    console.log(data);
                    console.log(moment())
                    //var one = data.split(",");
                    //var arr = [];
                    //arr.push(one);
                    //self.newOption = distribute(arr);
                }
            }
            xhr.send();
        }
        $(vm.$el).css("width", "1200px")
        $(vm.$el).css("height", "800px")
        vm.myChart = echarts.init(vm.$el);
        //console.log(vm.$el)
        //console.log(vm.myChart)
    },
    watch: {
        code: function (code) {
            var self=this;
            console.log("code changed:"+code)
            var xhr = new XMLHttpRequest();
            xhr.open('GET', "/" + code + ".json");
            var $quotation = app.push.hubs[0];
            //console.log(app.currentSecurity.name);
            xhr.onload = function () {
                var Simulatedata = JSON.parse(xhr.responseText);
                console.log(Simulatedata)
                var data = distribute(Simulatedata);
                //console.log(self.newOption);
                self.myChart.setOption({}, true);
                self.myChart.setOption(data, true);
                $quotation.client.getData = function (data) {
                    console.log(data);
                    console.log(moment())
                    //var one = data.split(",");
                    //var arr = [];
                    //arr.push(one);
                    //self.newOption = distribute(arr);
                }
            }
            xhr.send();
            console.log(code);

        }
    }
})


