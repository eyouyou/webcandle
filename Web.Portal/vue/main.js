Vue.prototype.$http = axios;
var app = new Vue({
    router,
    created: function () {
        window.addEventListener('keydown', this.keydown);
    },
    mounted: function () {
        var self = this;
        var $connection = self.push.connection,
            $quotation = $.connection.quotationhub;
        $connection = $.connection.hub;
        console.log($connection)
        $connection.logging = true;

        console.log($.connection);
        var quohub = {}
        self.push.hubs.push($quotation);
        $quotation.client.hubMessage = function (data) {
            console.log("message:" + data);
            console.log(moment().format('x'))

        }

        $connection.start().done(function () {
            console.log("starting")
            console.log($quotation.server)
            $quotation.server.startBackgroundThread();
        })
        $connection.connectionSlow(function () {
            console.log("connectionSlow")
        })

    },
    data: {
        keyboradElf: {
            search_key: "",
            is_show: false,
            count: 1,
            securityitems: []
        },
        push: {
            connection: {},
            hubs: []
        },
        currentSecurity: {}
    },
    methods: {
        keydown: function (event) {
            var keycode = event.keyCode || event.which;
            var char = String.fromCharCode(keycode);
            var $skey = $("#searchKey");
            var self = this.keyboradElf;
            self.is_show = true;
            if (self.count == 1) {
                Vue.nextTick(function () {
                    $skey.focus();
                    //$skey.val(char);
                });
            }
            console.log(char);
            var xhr = new XMLHttpRequest();
            xhr.open('GET', "/securities.json")
            xhr.onload = function () {
                self.securityitems = JSON.parse(xhr.responseText).objs;
                console.log(self.securityitems)
            }
            xhr.send();
            this.count++;
        },
        blur: function (e) {
            this.is_show = false;
        },
        redirect: function (e, item) {
            var target = e.target || window.event.srcElement;
            this.keyboradElf.count = 1;
            console.log(item);

            //路由或者请求页面
            //this.currentSecurity = item; 
            router.push({ name: 'chart', params: { securityId: item.code_display } })
        },
    },
    watch: {
        '$route'(to, from) {
            //console.log("to")
            //console.log(to);
            //K.securityId = 123;
        }
    }
}).$mount('#app');
