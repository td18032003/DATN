<template>
    <div>
        <sidebar :listOption="listSetting" :type="1"></sidebar>
        <div class="body-content">
            vào
        </div>
    </div>
</template>
<script>
import sidebar from "../../layout/sidebar/index";
export default {
    components: {
        sidebar
    },
    data(){
        return{
            listSetting: [
                {
                    ID: 1,
                    Name: "Không thời hạn",
                    Active: true,
                    Router: "/share/indefinite"
                },
                {
                    ID: 2,
                    Name: "Có thời hạn",
                    Active: false,
                    Router: "/share/time"
                },
                {
                    ID: 3,
                    Name: "Nhận chia sẽ",
                    Active: false,
                    Router: "/share/receive"
                }
            ]
        }
    }
}
</script>
<style lang="scss" scoped>

</style>