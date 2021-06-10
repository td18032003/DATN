<template>
    <div class="add-role">
        <div class="flex header">
            <div class="title">
                Thêm vai trò
            </div>
            <div class="flex">
                <cc-button class="m-r-12" type="secondary" @click="back">Hủy</cc-button>
                <cc-button @click="save">Lưu</cc-button>
            </div>
        </div>
        <div class="content">
            <cc-group title="Thông tin vai trò" class="m-b-24">
                <cc-row>
                    <cc-col w="15">
                        Tên vai trò
                    </cc-col>
                    <cc-col w="30" class="m-r-60">
                        <cc-input v-model="role.RoleName"></cc-input>
                    </cc-col>
                    <cc-col w="15">
                        Ghi chú
                    </cc-col>
                    <cc-col w="30">
                        <cc-input v-model="role.Note"></cc-input>
                    </cc-col>
                </cc-row>
            </cc-group>
            <cc-group title="Danh sách quyền chức năng">
                <div v-for="(item, index) in role.ListRole" :key="index" class="flex m-b-24">
                    <div class="role-name">
                        {{item.SubsystemName}}
                    </div>
                    <div class="flex">
                        <div v-for="(role, indexRole) in item.ListRoleDetail" :key="indexRole" class="item">
                            <cc-check-box :text="role.RoleName"></cc-check-box>
                        </div>
                    </div>
                </div>
            </cc-group>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            role: {
                RoleName: null,
                Note: null,
                ListRole: [
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
                    },
                    {
                        SubsystemCode: "Personal",
                        SubsystemName: "Cá nhân",
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
                    },
                    {
                        SubsystemCode: "Shared",
                        SubsystemName: "Chia sẻ",
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
                    },
                    {
                        SubsystemCode: "Employee",
                        SubsystemName: "Thiết lập/Nhân viên",
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
                                RoleName: "Sửa",
                                RoleCode: "Add"
                            },
                            {
                                IsCheck: false,
                                RoleName: "Xóa",
                                RoleCode: "Add"
                            }
                        ]
                    },
                    {
                        SubsystemCode: "Unit",
                        SubsystemName: "Thiết lập/Đơn vị",
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
                                RoleName: "Sửa",
                                RoleCode: "Add"
                            },
                            {
                                IsCheck: false,
                                RoleName: "Xóa",
                                RoleCode: "Add"
                            }
                        ]
                    },
                    {
                        SubsystemCode: "Unit",
                        SubsystemName: "Thiết lập/Người dùng",
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
                                RoleName: "Sửa",
                                RoleCode: "Add"
                            },
                            {
                                IsCheck: false,
                                RoleName: "Xóa",
                                RoleCode: "Add"
                            }
                        ]
                    },
                    {
                        SubsystemCode: "Unit",
                        SubsystemName: "Thiết lập/Vai trò",
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
                                RoleName: "Sửa",
                                RoleCode: "Add"
                            },
                            {
                                IsCheck: false,
                                RoleName: "Xóa",
                                RoleCode: "Add"
                            }
                        ]
                    },
                    {
                        SubsystemCode: "Unit",
                        SubsystemName: "Thiết lập/Email hệ thống",
                        ListRoleDetail: [
                            {
                                IsCheck: false,
                                RoleName: "Xem",
                                RoleCode: "Add"
                            },
                            {
                                IsCheck: false,
                                RoleName: "Sửa",
                                RoleCode: "Add"
                            },
                        ]
                    },
                    {
                        SubsystemCode: "Unit",
                        SubsystemName: "Thiết lập/Nhật ký hoạt động",
                        ListRoleDetail: [
                            {
                                IsCheck: false,
                                RoleName: "Xem",
                                RoleCode: "Add"
                            }
                        ]
                    }
                ]
            }
        }
    }
}
</script>
<style lang="scss" scoped>
.header{
    justify-content: space-between;
}
.add-role{
    height: calc(100% - 60px);
    .header{
        .title{
            font-size: 22px;
            font-weight: 500;
        }
        margin-bottom: 12px;
        align-items: center;
    }
    .role-name{
        width: 200px;
    }
    .item{
        width: 150px;
        margin-right: 12px;
    }
    .content{
        height: 100%;
        overflow: auto;
    }
}
</style>