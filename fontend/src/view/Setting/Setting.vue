<template>
    <div class="cc-setting">
        <sidebar :listOption="listSetting" :type="1"></sidebar>
        <div class="body-content">
            <router-view></router-view>
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
                    Name: "Thông tin nhân viên",
                    Active: true,
                    Router: "/setting/employee"
                },
                {
                    ID: 2,
                    Name: "Đơn vị công tác",
                    Active: false,
                    Router: "/setting/organization-unit"
                },
                {
                    ID: 3,
                    Name: "Tài khoản người dùng",
                    Active: false,
                    Router: "/setting/account"
                },
                {
                    ID: 4,
                    Name: "Vai trò",
                    Active: false,
                    Router: "/setting/role"
                },
            ]
        }
    }
}
</script>
<style lang="scss" scoped>
.cc-setting{
    .body-content{
        position: absolute;
        top: 0px;
        left: 233px;
        right: 0px;
        bottom: 0px;
        padding: 12px 16px 16px 16px;
    }
}
</style>