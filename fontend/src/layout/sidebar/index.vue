<template>
    <div class="cc-sidebar">
        <div v-if="type == 1">
            <div v-for="(item,index) in listOption" :key="index">
                <div class="item" :class="{'active': item.Active}" @click="changeRouter(item)">
                    {{item.Name}}
                </div>
            </div>
        </div>
        <div v-if="type == 2">
            <DxTreeView
                ref="treeViewOrg"
                :data-source="dataSource"
                :select-by-click="true"
                data-structure="plain"
                key-expr="OrganizationUnitID"
                parent-id-expr="ParentID"
                selection-mode="single"
                display-expr="OrganizationUnitName"
                @item-click="selectItem"
            />
        </div>
    </div>
</template>
<script>
import DxTreeView from 'devextreme-vue/tree-view';
export default {
    components:{
        DxTreeView
    },
    props: {
        type: {
            Type: Number,
            default: 2
        },
        listOption: {
            Type: Array,
            default: () => []
        }
    },
    data(){
        return{
            value: [],
            dataSource: [
                {
                    OrganizationUnitID: 1,
                    OrganizationUnitName: "ĐHQG Hà Nội",
                    ParentID: 0
                },
                {
                    OrganizationUnitID: 2,
                    OrganizationUnitName: "ĐHQG Hà Nội",
                    ParentID: 1
                },
                {
                    OrganizationUnitID: 3,
                    OrganizationUnitName: "ĐHQG Hà Nội",
                    ParentID: 1
                },
                {
                    OrganizationUnitID: 4,
                    OrganizationUnitName: "ĐHQG Hà Nội",
                    ParentID: 2
                }
            ],
        }
    },
    methods: {
        selectItem(e){

        },
        changeRouter(item){
            this.listOption.forEach(ele => {
                if(ele.ID == item.ID){
                    ele.Active = true;
                }
                else{
                    ele.Active = false;
                }
            })
            this.$router.push("/home" + item.Router);
        }
    },
    created(){
       
    }
}
</script>
<style lang="scss" scoped>
.cc-sidebar{
    .item{
        height: 42px;
        padding: 0 16px;
        display: flex;
        align-items: center;
        cursor: pointer;
        margin-bottom: 8px;
        border-radius: 4px;
        &:hover{
            background-color: #d7e2ff;
        }
    }
    .active{
        color: #524aff !important;
        background-color: #d7e2ff;
    }
}
</style>
<style lang="scss">
.cc-sidebar{
    position: absolute;
    top: 0px;
    left: 0px;
    bottom: 0px;
    width: 200px;
    border-right: 1px solid #DDDDDD;
    padding: 12px 16px;
    background-color: #fff;
    .dx-treeview-item{
        display: flex;
        vertical-align: middle;
        height: 34px;
        padding: 5px 8px;
        border-radius: 4px;
        margin-bottom: 2px;
    }
    .dx-treeview-item-without-checkbox.dx-state-selected > .dx-treeview-item{
        color: #524aff !important;
        background-color: #d7e2ff !important;
        font-weight: 500;
    }
    .dx-treeview-item-without-checkbox.dx-state-focused > .dx-treeview-item{
        color: #524aff ;
        background-color: #d7e2ff ;
    }
    .dx-treeview-item.dx-state-hover{
        color: #212121 ;
        background-color: #d7e2ff ;
    }
    .dx-treeview-toggle-item-visibility{
        top: 7px;
        left: 0px;
        width: 24px;
        height: 24px;
        -webkit-mask-position: -120px -24px;
        -moz-mask-position: -120px -24px;
        -ms-mask-position: -120px -24px;
        -o-mask-position: -120px -24px;
        mask-position: -120px -24px;
        margin-right: 10px;
        -webkit-mask-image: url("~@/assets/icon/Icon.svg") !important;
        -moz-mask-image: url("~@/assets/icon/Icon.svg") !important;
        -ms-mask-image: url("~@/assets/icon/Icon.svg") !important;
        -o-mask-image: url("~@/assets/icon/Icon.svg") !important;
        mask-image: url("~@/assets/icon/Icon.svg") !important;
        -webkit-mask-repeat: no-repeat;
        -moz-mask-repeat: no-repeat;
        -ms-mask-repeat: no-repeat;
        -o-mask-repeat: no-repeat;
        mask-repeat: no-repeat;
        background-color: #666666;
        &::before{
            content: none;
        }
    }
    .dx-treeview-toggle-item-visibility.dx-treeview-toggle-item-visibility-opened{
        -webkit-mask-position: -72px -24px !important;
        -moz-mask-position: -72px -24px !important;
        -ms-mask-position: -72px -24px !important;
        -o-mask-position: -72px -24px !important;
        mask-position: -72px -24px !important;
    }
    .dx-treeview-node{
        padding-left: 20px;
    }
}
</style>