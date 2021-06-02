<template>
    <div class="body-organization-unit">
        <sidebar></sidebar>
        <div class="body-content">
            <div class="header flex">
                <div class="flex">
                    <div class="tilte">Đơn vị hiện tại</div>
                </div>
                <div class="flex">
                    <cc-input class="m-r-12" width="200px" icon="icon-search" placeholderInput="Tìm kiếm tài liệu"></cc-input>
                    <cc-button type="primary m-r-12" icon="icon-plus-white" @click="openAddFile">Tải tệp</cc-button>
                    <cc-button type="primary m-r-12" icon="icon-plus-white" @click="openAddFolder">Tạo thư mục</cc-button>
                    <cc-icon type="primary-border m-r-12" icon="icon-filter"></cc-icon>
                    <div class="flex type">
                        <div class="type-show" :class="[{'active': typeshow == 1}]" @click="typeshow = 1">
                            <div class="icon-list-block"></div>
                        </div>
                        <div class="type-show" :class="[{'active': typeshow == 2}]" @click="typeshow = 2">
                            <div class="icon-list-dote"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content" v-if="typeshow == 1">
                <div v-for="(item,index) in dataSource" :key="index" class="item">
                    <div class="item-folder">
                        <div class="flex btn-hover">
                            <cc-icon class="btn-none m-r-12" type="circle" icon="icon-export"></cc-icon>
                            <cc-icon class="btn-none" type="circle" icon="icon-delete"></cc-icon>
                        </div>
                        <div class="flex justify-center m-b-16">
                            <img class="img-folder" src="@/assets/image/icon-file.png"/>
                        </div>
                        <div class="flex justify-center">
                            {{item.FileName}}
                        </div>
                        <div class="flex justify-center text-secondary">
                            {{item.Size}}
                        </div>
                        <div class="flex justify-center text-secondary">
                            {{item.CreatedDate}}
                        </div>
                    </div>
                </div>
            </div>
            <div class="content-list" v-if="typeshow == 2">
                <ccTable 
                    :listHeader="listHeader" 
                    :dataSource="dataSource"
                    @clickEdit="openEdit"
                    @clickDelete="confirmDelete">
                </ccTable>
            </div>
        </div>
        <AddFolder v-if="activeAddFolder"  @save="afterSave" v-model="activeAddFolder" :listFolder="listFolder"></AddFolder>
        <PopupUploadFile v-if="activePopup" v-model="activePopup" @save="afterSave" :listFolder="listFolder"></PopupUploadFile>
    </div>
</template>
<script>
import sidebar from "../../layout/sidebar";
import FileAPI from '@/api/Components/FileAPI.js';
import AddFolder from "./AddFolder";
import PopupUploadFile from "./PopupUploadFile";
export default {
    components: {
        sidebar,
        AddFolder,
        PopupUploadFile
    },
    data(){
        return{
            typeshow: 1,
            dataSource: [],
            listHeader: [
                {
                    DataField: "FileName",
                    Caption: "Tên tệp",
                    DataTyle: "text",
                    Fixed: true,
                    MinWidth: 150
                },
                {
                    DataField: "OrganizationUnitName",
                    Caption: "Đơn vị",
                    DataTyle: "text",
                    Fixed: true,
                    MinWidth: 150
                },
                {
                    DataField: "CreatedBy",
                    Caption: "Người tạo",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "CreatedDate",
                    Caption: "Ngày tạo",
                    DataTyle: "date",
                    MinWidth: 150
                },
                {
                    DataField: "TypeFile",
                    Caption: "Loại file",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "Note",
                    Caption: "Ghi chú",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "Size",
                    Caption: "Kích thước",
                    DataTyle: "text",
                    MinWidth: 150
                },
            ],
            activeAddFolder: false,
            listFolder: [],
            activePopup: false
        }
    },
    methods: {
        openAddFile(){
            this.activePopup = true;
        },
        openAddFolder(){
            this.activeAddFolder = true;
        },
        afterSave(){
            this.activePopup = false;
            this.activeAddFolder = false;
            this.getFilePersonal();
        },
    }
}
</script>
<style lang="scss" scoped>
@import '@/styles/var-color.scss';
.body-organization-unit{
    width: 100%;
    height: 100%;
    .body-content{
        position: absolute;
        top: 0;
        right: 0;
        bottom: 0;
        left: 233px;
        padding: 0 24px 24px 24px;
        .header{
            display: flex;
            align-items: center;
            
            padding: 12px 0px;
            justify-content: space-between;
            .tilte{
                font-weight: 500;
                font-size: 18px;
            }
        }
        .content{
            display: flex;
            flex-wrap: wrap;
            height: calc(100% - 68px);
            overflow: auto;
            .item{
                .item-folder{
                    padding: 16px;
                    width: 180px;
                    height: auto;
                    background-color: #ffffff;
                    margin: 0 24px 24px 0;
                    border-radius: 8px;
                    border: 1px solid #ffffff;
                    .img-folder{
                        width: 100px;
                        height: 80px;
                    }
                    .btn-hover{
                        height: 36px;
                        margin-bottom: 4px;
                        justify-content: flex-end;
                        .btn-none{
                            display: none;
                            float: right;
                        }
                    }
                    &:hover{
                        border: 1px solid $primary-hover;
                        cursor: pointer;
                        .btn-none{
                            display: flex !important;
                            float: right;
                        }
                    }
                }
            }
        }
    }
    .content-list{
        display: flex;
        flex-wrap: wrap;
        height: calc(100% - 68px) !important;
        height: auto;
        overflow: auto;
        .item{
            height: 48px;
            margin: 0px 8px 4px 0px;
            .item-folder-list{
                align-items: center;
                width: 480px;
                height: 48px;
                padding: 0 8px;
                border-radius: 4px;
                background-color: #ffffff;
                border: 1px solid #ffffff;
                .img-folder{
                    width: 28px;
                    height: 28px;
                }
                .text-name{
                    width: 200px;
                    text-overflow: ellipsis;
                    justify-content: left;
                }
                &:hover{
                    border: 1px solid $primary-hover;
                    background-color: #d7e2ff !important;
                    cursor: pointer;
                    .btn-none{
                        display: flex !important;
                        float: right;
                    }
                }
            }
        }
    }
    .type{
        border-radius: 4px;
        background-color: #c1c1c1;
        .active{
            background-color: #ffffff;
        }
    }
    .type-show{
        width: 36px;
        height: 36px;
        border-radius: 4px;
        display: flex;
        align-items: center;
        justify-content: center;
    }
}
</style>