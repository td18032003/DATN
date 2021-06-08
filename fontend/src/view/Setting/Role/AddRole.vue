<template>
    <div>
        <div class="flex header">
            <div>
                Thêm vai trò
            </div>
            <div class="flex">
                <cc-button class="m-r-12" type="secondary" @click="back">Hủy</cc-button>
                <cc-button @click="save">Lưu</cc-button>
            </div>
        </div>
        <div>
            <div v-for="(item, index) in listRole" :key="index" class="flex">
                <div class="role-name">
                    {{item.SubsystemName}}
                </div>
                <div>
                    <div v-for="(role, indexRole) in item.ListRoleDetail" :key="indexRole">
                        <cc-check-box :text="role.RoleName"></cc-check-box>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            listRole: [
                {
                    SubsystemCode: "OrganizationUnit",
                    SubsystemName: "Đơn vị",
                    ListRoleDetail: [
                        {
                            IsCheck: false,
                            RoleName: "Xem",
                            RoleCode: "Add"
                        },
                        {
                            IsCheck: false,
                            RoleName: "Thêm",
                            RoleCode: "Add"
                        },
                        {
                            IsCheck: false,
                            RoleName: "Xóa",
                            RoleCode: "Add"
                        },
                        {
                            IsCheck: false,
                            RoleName: "Tải xuống",
                            RoleCode: "Add"
                        },
                    ]
                }
            ]
        }
    }
}
</script>
<style lang="scss" scoped>
.header{
    justify-content: space-between;
}
.add-role{
    .role-name{
        width: 300px;
    }
}
</style>