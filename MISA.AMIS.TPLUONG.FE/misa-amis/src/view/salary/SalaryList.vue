<template>
  <div class="content">
    <div class="header-content flex">
      <TitleSalary :title="title" />
      <div class="box-btn-add">
        <button class="m-btn btn-add" @click="openModal">
          <div class="icon-add"></div>
          <div class="text-btn">Thêm mới</div>
        </button>
      </div>
    </div>
    <div class="wrapper-content flex">
      <div class="wrapper-content-left" :class="{ 'w-78': !hiddenPopupFilter }">
        <div class="toolbar-content flex relative" v-if="countRowChecked == 0">
          <div class="box-search relative">
            <input
              type="text"
              class="m-input input-search"
              placeholder="Tìm kiếm"
              v-model="keysearch"
              @keyup.enter="searchByKeysearch"
            />
            <div class="icon-search"></div>
          </div>
          <div class="toolbar-right flex">
            <BaseDropdown
              style="margin-right: 20px"
              :data="statusData"
              :widthDropdown="120"
              :widthDropdownData="230"
              :topDropdownData="42"
              :rightDropdownData="0"
              @get="getValueStatus"
            />
            <BaseDropdownSingle
              style="margin-right: 10px; width: 316px"
              :treeDataSource="treeDataSource"
              :placeholderProp="'Tất cả đơn vị'"
              :valueExprProp="'OrganizationUnitID'"
              :displayExprProp="'OrganizationUnitName'"
              :parentIdExprProp="'ParentID'"
              :valueDefault="
                treeDataSource && treeDataSource.length > 0
                  ? treeDataSource[7].OrganizationUnitID
                  : null
              "
              @getValueOrganizationUnit="getValueOrganizationUnit"
            />
            <div class="box-filter-toolbar" @click="openPopupFilter">
              <div class="icon-filter-toolbar"></div>
            </div>
            <div class="box-setting-toolbar" @click="openCustomizeColumn">
              <div class="icon-setting-toolbar"></div>
              <BaseCustomizeColumn
                :hiddenCustomizeColumn="hiddenCustomizeColumn"
                :headersDefault="headersDefault"
                :headers="headers"
                :headerGrid="headerGrid"
                @closeCustomizeColumn="closeCustomizeColumn"
                @customizeColumn="customizeColumn"
                @refreshColumn="refreshColumn"
              />
            </div>
          </div>
        </div>
        <div class="toolbar-content flex relative" v-else>
          <span class="text-toolbar"
            >Đã chọn <b>{{ countRowChecked }}</b></span
          >
          <span class="uncheck-all" @click="uncheckAll">Bỏ chọn</span>
          <div class="box-btn-unfollow-all">
            <button
              class="m-btn btn-unfollow-all"
              @click="openPopupUnfollowMulti"
            >
              <div class="icon-unfollow"></div>
              <div class="text-btn">Ngừng theo dõi</div>
            </button>
          </div>
          <div class="box-btn-follow-all">
            <button class="m-btn btn-follow-all" @click="openPopupFollowMulti">
              <div class="icon-follow"></div>
              <div class="text-btn">Đang theo dõi</div>
            </button>
          </div>
          <div class="box-btn-deletes">
            <button class="m-btn btn-deletes" @click="openPopupDeleteMulti">
              <div class="icon-deletes"></div>
              <div class="text-btn">Xoá</div>
            </button>
          </div>
        </div>
        <div class="table-salary">
          <BaseGrid
            ref="baseGrid"
            :headers="headers"
            :headersDefault="headersDefault"
            :headerGrid="headerGrid"
            :dataSource="dataSource"
            @getRowChecked="getRowChecked"
            @onRowDblClick="rowDblClick"
            @openFormDetail="openFormDetail"
            @openPopupDelete="openPopupDelete"
            @openPopupUnfollow="openPopupUnfollow"
            @cloneRow="cloneRow"
            @openPopupFollow="openPopupFollow"
          >
            <template #StatusName="{ data }">
              <div
                class="box-status flex a-l-c"
                v-if="data.StatusName == 'Đang theo dõi'"
              >
                <div class="icon-status"></div>
                <div class="text-status">{{ data.StatusName }}</div>
              </div>
              <div class="box-status flex a-l-c" v-else>
                <div
                  class="icon-status"
                  style="background-color: rgb(255, 153, 0)"
                ></div>
                <div class="text-status" style="color: rgb(255, 153, 0)">
                  {{ data.StatusName }}
                </div>
              </div>
            </template>
            <template #Quota="{ data }">
              {{ formatPrice(data.Quota) }}
            </template>
          </BaseGrid>

          <div class="box-paging">
            <div class="paging">
              <div class="amount">
                Tổng số bản ghi: <b>{{ amountPage }}</b>
              </div>
              <div class="box-pagination flex a-l-c">
                <span style="margin-right: 20px">Số bản ghi/trang</span>
                <BaseDropdown
                  style="margin-right: 30px"
                  :data="dataPage"
                  :widthDropdown="60"
                  :widthDropdownData="60"
                  :topDropdownData="-150"
                  :rightDropdownData="10"
                  @get="getValuePageSize"
                />
                <div class="pageIndex flex a-l-c">
                  <div style="margin-right: 70px">
                    <span
                      ><b>{{ startRecord }}</b
                      ><span style="margin-left: 3px; margin-right: 3px">-</span
                      ><b>{{ endRecord }}</b> bản ghi</span
                    >
                  </div>
                  <paginate
                    :page-count="numPages"
                    :margin-pages="1"
                    :container-class="'pagination'"
                    :page-class="'page-item'"
                    :prev-link-class="'btn-pre'"
                    :next-link-class="'btn-next'"
                    :click-handler="clickPaging"
                    ref="pagination"
                  >
                  </paginate>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div
        class="wrapper-content-right"
        :class="{ 'w-22': !hiddenPopupFilter }"
      >
        <BaseFilter
          :hiddenPopupFilter="hiddenPopupFilter"
          :headerFilter="headerFilter"
          @closePopupFilter="closePopupFilter"
        />
      </div>
    </div>
    <SalaryDetail
      ref="modeForm"
      :isOpenModal="isOpenModal"
      :treeDataSource="treeDataSource"
      @closePopup="closePopup"
      @closeForm="closeForm"
      @reloadTableAndFilter="reloadTableAndFilter"
      @openPopupDataChange="openPopupDataChange"
      @cloneRow="cloneRow"
      @openPopupDelete="openPopupDelete"
    />
    <BasePopup
      v-if="!hiddenPopup"
      :titlePopup="titlePopup"
      :textPopup="textPopup"
      :statusPopup="statusPopup"
      @closePopup="closePopup"
      @deleteRow="deleteRow"
      @unfollowRow="unfollowRow"
      @unfollowMultiRow="unfollowMultiRow"
      @deleteMultiRow="deleteMultiRow"
      @closeForm="closeForm"
      @saveBtnClick="saveBtnClick"
      @followRow="followRow"
      @followMultiRow="followMultiRow"
    />
    <BaseLoading :isLoading="isLoading" />
  </div>
</template>

<script>
import TitleSalary from "../../components/base/BaseTitle.vue";
import BaseDropdownSingle from "../../components/base/BaseDropdownSingle.vue";
import BaseGrid from "../../components/base/BaseGrid.vue";
import SalaryDetail from "../salary/SalaryDetail.vue";
import {
  URL_API,
  HEADERS,
  HEADERS_DEFAULT,
  HEADERS_FILTER,
  STATUS_DATA_FILTER,
  PAGE_DATA,
} from "../../js/common/data.js";
import BaseDropdown from "../../components/base/BaseDropdown.vue";
import BaseCustomizeColumn from "../../components/base/BaseCustomizeColumn.vue";
import BaseFilter from "../../components/base/BaseFilter.vue";
import axios from "axios";
import BasePopup from "../../components/base/BasePopup.vue";
import stringInject from "stringinject";
import { MODE, STATUS_POPUP } from "../../js/common/mode";
import { MESSAGE } from "../../js/common/message";
import BaseLoading from "../../components/base/BaseLoading.vue";
export default {
  name: "SalaryList",
  components: {
    TitleSalary,
    BaseDropdownSingle,
    BaseGrid,
    SalaryDetail,
    BaseDropdown,
    BaseCustomizeColumn,
    BaseFilter,
    BasePopup,
    BaseLoading,
  },
  data() {
    return {
      isLoading: false,
      // title page
      title: "Thành phần lương",
      // mở modal
      isOpenModal: true,
      // data source treeview
      treeDataSource: [],
      // count rowchecked
      countRowChecked: 0,
      // data source grid
      dataSource: [],
      // header grid
      headers: [...HEADERS],
      headersDefault: [...HEADERS_DEFAULT],
      headerGrid: [...HEADERS_DEFAULT],
      headerFilter: HEADERS_FILTER,
      statusData: STATUS_DATA_FILTER,
      dataPage: PAGE_DATA,
      // trang hiện tại
      pageIndex: 1,
      // value pageSize
      pageSize: 15,
      // value status
      statusID: "",
      // value dropdown filter
      organizationUnitID: "",
      // value input search
      keysearch: "",
      // tổng số bản ghi
      amountPage: 0,
      // tổng số trang
      numPages: 0,
      // bắt đầu từ bản ghi
      startRecord: 0,
      // kết thúc tại bản ghi
      endRecord: 0,
      page: 1,
      // mode form detail : 0 là add, 1 là edit
      modeFormDetail: MODE.ADD,
      // ẩn tùy chỉnh cột
      hiddenCustomizeColumn: true,
      // ẩn popup filter
      hiddenPopupFilter: true,
      // ẩn popup
      hiddenPopup: true,
      // ID thành phần lương
      salaryCompositionID: "",
      // title popup
      titlePopup: "",
      textPopup: "",
      // trạng thái popup: 0 là delete, 1 là unfollow, 2 là unfollow multi, 3 là delete multi, 4 là datachange, 5 là follow, 6 là follow multi
      statusPopup: STATUS_POPUP.DELETE,
      // mảng ID
      salaryCompositionIDs: [],
    };
  },
  created() {
    // lấy ra toàn bộ danh sách thành phần lương
    this.getSalaryCompositionByFilter(
      this.pageIndex,
      this.pageSize,
      this.statusID,
      this.organizationUnitID,
      this.keysearch
    );
  },
  mounted() {
    // lấy ra danh sách đơn vị
    this.getOrganizationUnits();
  },
  methods: {
    /**----------------------------------------------------
     * Lấy ra danh sách thành phần lương theo filter
     * CreatedBy:LQNHAT(19/09/2021)
     */
    getSalaryCompositionByFilter() {
      var self = this;
      self.isLoading = true;
      axios
        .get(
          URL_API.API_SALARYCOMPOSITION +
            "/filter?pageIndex=" +
            self.pageIndex +
            "&pageSize=" +
            self.pageSize +
            "&statusID=" +
            self.statusID +
            "&organizationUnitID=" +
            self.organizationUnitID +
            "&keysearch=" +
            self.keysearch
        )
        .then((res) => {
          // lấy ra data
          self.dataSource = res.data.Data;
          // lấy ra tổng số bản ghi
          self.amountPage = res.data.TotalRecord;
          // lấy ra số lượng trang
          self.numPages = res.data.TotalPage;
          // set value startRecord, endRecord
          self.startRecord = (self.pageIndex - 1) * self.pageSize + 1;
          self.endRecord =
            self.amountPage < self.pageSize * self.pageIndex
              ? self.amountPage
              : self.pageSize * self.pageIndex;
          self.isLoading = false;
        });
    },

    /**--------------------------------------------------------------------
     * Reload lại data của bảng
     * CreatedBy:LQNHAT(20/09/2021)
     */
    reloadTableAndFilter() {
      var self = this;
      self.isLoading = true;
      axios
        .get(
          URL_API.API_SALARYCOMPOSITION +
            "/filter?pageIndex=" +
            self.pageIndex +
            "&pageSize=" +
            self.pageSize
        )
        .then((res) => {
          // lấy ra data
          self.dataSource = res.data.Data;
          // lấy ra tổng số bản ghi
          self.amountPage = res.data.TotalRecord;
          // lấy ra số lượng trang
          self.numPages = res.data.TotalPage;
          // set value startRecord, endRecord
          self.startRecord = (self.pageIndex - 1) * self.pageSize + 1;
          self.endRecord =
            self.amountPage < self.pageSize * self.pageIndex
              ? self.amountPage
              : self.pageSize * self.pageIndex;
          self.isLoading = false;
          // quay về trang đầu tiên
          self.$refs.pagination.selectFirstPage();
        });
    },

    /**------------------------------------------------------------------------
     * Lấy ra danh sách đơn vị
     * CreatedBy:LQNHAT(20/09/2021)
     */
    getOrganizationUnits() {
      var self = this;
      axios.get(URL_API.API_ORGANIZATIONUNIT).then((res) => {
        self.treeDataSource = res.data;
      });
    },

    /**-------------------------------------------------------------------
     * Bắt sự kiện chuyển trang
     * CreatedBy:LQNHAT(20/09/2021)
     */
    clickPaging(pageNum) {
      this.pageIndex = pageNum;
      this.getSalaryCompositionByFilter(
        this.pageIndex,
        this.pageSize,
        this.statusID,
        this.organizationUnitID,
        this.keysearch
      );
    },

    /**------------------------------------------------
     * Customize column
     * CreatedBy: LQNHAT(24/09/2021)
     */
    customizeColumn(headers) {
      this.headerGrid = [...headers.filter((i) => i.Checked === true)];
      this.headers = [...headers];
    },

    /**----------------------------------------------
     * Refresh column
     * CreatedBy: LQNHAT(24/09/2021)
     */
    refreshColumn() {
      this.headersDefault = [...HEADERS_DEFAULT];
      this.headerGrid = [...this.headersDefault];
      this.headers = [...this.headersDefault];
    },

    /**------------------------------------------------
     * Bắt sự kiện mở form chi tiết
     * CreatedBy: LQNHAT(14/09/2021)
     */
    openModal() {
      this.isOpenModal = !this.isOpenModal;
      this.modeFormDetail = MODE.ADD;
      this.$refs.modeForm.show(this.modeFormDetail);
    },

    /**--------------------------------------------------------
     * Bắt sự kiện khi dblclick mở form sửa
     * CreatedBy: LQNHAT(21/09/2021)
     */
    rowDblClick(data) {
      this.salaryCompositionID = data.SalaryCompositionID;
      this.isOpenModal = !this.isOpenModal;
      this.modeFormDetail = MODE.EDIT;
      this.$refs.modeForm.show(this.modeFormDetail, this.salaryCompositionID);
    },

    /**------------------------------------------------------------------------
     * Bắt sự kiện khi click icon sửa
     * CreatedBy: LQNHAT(23/09/2021)
     */
    openFormDetail(data) {
      this.salaryCompositionID = data.SalaryCompositionID;
      this.isOpenModal = !this.isOpenModal;
      this.modeFormDetail = MODE.EDIT;
      this.$refs.modeForm.show(this.modeFormDetail, this.salaryCompositionID);
      this.$refs.modeForm.openBoxBtn();
    },

    /**---------------------------------------------------------------------------
     * Bắt sự kiện nhân bản
     * CreatedBy: LQNHAT(23/09/2021)
     */
    cloneRow(data) {
      this.isOpenModal = !this.isOpenModal;
      this.$refs.modeForm.cloneSalaryComposition(data);
    },

    /**------------------------------------------------------------------------
     * Bắt sự kiện click vào icon xóa
     * CreatedBy: LQNHAT(21/09/2021)
     */
    openPopupDelete(data) {
      this.salaryCompositionID = data.SalaryCompositionID;
      this.statusPopup = STATUS_POPUP.DELETE;
      this.hiddenPopup = false;
      this.titlePopup = MESSAGE.TITLE_POPUP_NOTICE;
      this.textPopup = stringInject(MESSAGE.TEXT_POPUP_DELETE, [
        data.SalaryCompositionName,
      ]);
    },

    /**--------------------------------------------------------------------------
     * Xóa dòng
     * CreatedBy: LQNHAT(21/09/2021)
     */
    deleteRow() {
      var self = this;
      self.hiddenPopup = true;
      axios
        .delete(URL_API.API_SALARYCOMPOSITION + "/" + self.salaryCompositionID)
        .then(() => {
          self.$toast.success(MESSAGE.TEXT_SUCCESS_DELETE, {
            timeout: 2000,
          });
          self.reloadTableAndFilter();
          self.closeForm();
        });
    },

    /**-----------------------------------------------------------------------------------------------
     * mở popup unfollow
     * CreatedBy: LQNHAT(22/09/2021)
     */
    openPopupUnfollow(data) {
      this.salaryCompositionID = data.SalaryCompositionID;
      this.statusPopup = STATUS_POPUP.UNFOLLOW;
      this.hiddenPopup = false;
      this.titlePopup = MESSAGE.TITLE_POPUP_CHANGE_STATUS;
      this.textPopup = stringInject(MESSAGE.TEXT_POPUP_UNFOLLOW, [
        data.SalaryCompositionName,
      ]);
    },

    /**---------------------------------------------------------------------------------------------------
     * unfollow
     * CreatedBy: LQNHAT(22/09/2021)
     */
    unfollowRow() {
      var self = this;
      self.hiddenPopup = true;
      axios
        .put(
          URL_API.API_SALARYCOMPOSITION +
            "/unfollow?salaryCompositionID=" +
            self.salaryCompositionID
        )
        .then(() => {
          self.$toast.success(MESSAGE.TEXT_SUCCESS_UPDATE, {
            timeout: 2000,
          });
          self.reloadTableAndFilter();
        });
    },

    /**---------------------------------------------------------------------------------------------
     * Mở popup follow
     * CreatedBy: LQNHAT(24/09/2021)
     */
    openPopupFollow(data) {
      this.salaryCompositionID = data.SalaryCompositionID;
      this.statusPopup = STATUS_POPUP.FOLLOW;
      this.hiddenPopup = false;
      this.titlePopup = MESSAGE.TITLE_POPUP_CHANGE_STATUS;
      this.textPopup = stringInject(MESSAGE.TEXT_POPUP_FOLLOW, [
        data.SalaryCompositionName,
      ]);
    },

    /**------------------------------------------------------------------------------------------------------
     * Đang theo dõi
     * CreatedBy: LQNHAT(26/09/2021)
     */
    followRow() {
      var self = this;
      self.hiddenPopup = true;
      axios
        .put(
          URL_API.API_SALARYCOMPOSITION +
            "/follow?salaryCompositionID=" +
            self.salaryCompositionID
        )
        .then(() => {
          self.$toast.success(MESSAGE.TEXT_SUCCESS_UPDATE, {
            timeout: 2000,
          });
          self.reloadTableAndFilter();
        });
    },

    /**----------------------------------------------------------------------------------------------------
     * Mở popup unfollow multi
     * CreatedBy: LQNHAT(22/09/2021)
     */
    openPopupUnfollowMulti() {
      this.statusPopup = STATUS_POPUP.UNFOLLOW_MULTI;
      this.hiddenPopup = false;
      this.titlePopup = MESSAGE.TITLE_POPUP_CHANGE_STATUS;
      this.textPopup = MESSAGE.TEXT_POPUP_UNFOLLOW_MULTI;
    },

    /**------------------------------------------------------------------------------------------------------
     * Unfollow multu
     * CreatedBy: LQNHAT(22/09/2021)
     */
    unfollowMultiRow() {
      var self = this;
      self.hiddenPopup = true;
      axios
        .put(
          URL_API.API_SALARYCOMPOSITION +
            "/?entitesId=" +
            self.salaryCompositionIDs
        )
        .then(() => {
          self.$toast.success(MESSAGE.TEXT_SUCCESS_UPDATE, {
            timeout: 2000,
          });
          self.reloadTableAndFilter();
        });
    },

    /**---------------------------------------------------------------------------------------------------
     * Mở popup follow multi
     * CreatedBy: LQNHAT(24/09/2021)
     */
    openPopupFollowMulti() {
      this.statusPopup = STATUS_POPUP.FOLLOW_MULTI;
      this.hiddenPopup = false;
      this.titlePopup = MESSAGE.TITLE_POPUP_CHANGE_STATUS;
      this.textPopup = MESSAGE.TEXT_POPUP_FOLLOW_MULTI;
    },

    /**----------------------------------------------------------------------------------------------------
     * Follow multi
     * CreatedBy: LQNHAT(24/09/2021)
     */
    followMultiRow() {
      var self = this;
      self.hiddenPopup = true;
      axios
        .put(
          URL_API.API_SALARYCOMPOSITION +
            "/followMulti?entitesId=" +
            self.salaryCompositionIDs
        )
        .then(() => {
          self.$toast.success(MESSAGE.TEXT_SUCCESS_UPDATE, {
            timeout: 2000,
          });
          self.reloadTableAndFilter();
        });
    },

    /**-----------------------------------------------------------------------
     * Mở popup delete multi
     * CreatedBy: LQNHAT(22/09/2021)
     */
    openPopupDeleteMulti() {
      this.statusPopup = STATUS_POPUP.DELETE_MULTI;
      this.hiddenPopup = false;
      this.titlePopup = MESSAGE.TITLE_POPUP_NOTICE;
      this.textPopup = MESSAGE.TEXT_POPUP_DELETE_MULTI;
    },

    /**-----------------------------------------------------------------------
     * Delete multi
     * CreatedBy: LQNHAT(22/09/2021)
     */
    deleteMultiRow() {
      var self = this;
      self.hiddenPopup = true;
      axios
        .delete(
          URL_API.API_SALARYCOMPOSITION +
            "/?entitesId=" +
            self.salaryCompositionIDs
        )
        .then(() => {
          self.$toast.success(MESSAGE.TEXT_SUCCESS_DELETE, {
            timeout: 2000,
          });
          self.reloadTableAndFilter();
        });
    },

    /**---------------------------------------------------------------------
     * Mở popup khi dữ liệu thay đổi
     * CreatedBy: LQNHAT(23/09/2021)
     */
    openPopupDataChange() {
      this.statusPopup = STATUS_POPUP.DATA_CHANGE;
      this.hiddenPopup = false;
      this.titlePopup = MESSAGE.TITLE_POPUP_NOTICE;
      this.textPopup = MESSAGE.TEXT_POPUP_DATE_CHANGE;
    },

    /**-------------------------------------------------------------------------
     * Bắt sự kiện nút lưu bên popup data  change
     * CreatedBy: LQNHAT(23/09/2021)
     */
    saveBtnClick() {
      this.$refs.modeForm.saveBtnClick();
    },

    /**-----------------------------------------------------------------------
     * Đóng popup
     * CreatedBy: LQNHAT(21/09/2021)
     */
    closePopup() {
      this.hiddenPopup = true;
    },

    /**---------------------------------------------------------
     * Bắt sự kiện đóng form chi tiết
     * CreatedBy : LQNHAT(14/09/2021)
     */
    closeForm() {
      this.isOpenModal = true;
      this.reloadTableAndFilter();
    },

    /**----------------------------------------------------------
     * Mở form tùy chỉnh cột
     * CreatedBy:LQNHAT(20/09/2021)
     */
    openCustomizeColumn() {
      this.hiddenCustomizeColumn = false;
      event.stopPropagation();
    },

    /**----------------------------------------------------------------
     * Đóng form tùy chỉnh cột
     * CreatedBy:LQNHAT(20/09/2021)
     */
    closeCustomizeColumn() {
      this.hiddenCustomizeColumn = true;
      event.stopPropagation();
    },

    /**----------------------------------------------------------------
     * Mở popup filter
     * CreatedBy:LQNHAT(20/09/2021)
     */
    openPopupFilter() {
      this.hiddenPopupFilter = !this.hiddenPopupFilter;
    },

    /**------------------------------------------------------------------
     * Đóng popup filter
     * CreatedBy:LQNHAT(20/09/2021)
     */
    closePopupFilter() {
      this.hiddenPopupFilter = true;
    },

    /**-----------------------------------
     * Set value cho status để filter
     * CreatedBy : LQNHAT(14/09/2021)
     */
    getValueStatus(value) {
      this.statusID = value;
      // quay về trang đầu tiên
      this.$refs.pagination.selectFirstPage();
      this.getSalaryCompositionByFilter(
        this.pageIndex,
        this.pageSize,
        this.statusID,
        this.organizationUnitID,
        this.keysearch
      );
    },

    /**------------------------------------
     * Set value cho pageSize
     * CreatedBy: LQNHAT(16/09/2021)
     */
    getValuePageSize(value) {
      this.pageSize = value;
      this.$refs.pagination.selectFirstPage();
      this.getSalaryCompositionByFilter(
        this.pageIndex,
        this.pageSize,
        this.statusID,
        this.organizationUnitID,
        this.keysearch
      );
    },

    /**---------------------------------------------
     * Set value cho OrganizationUnit
     * CreatedBy:LQNHAT(20/09/2021)
     */
    getValueOrganizationUnit(value) {
      if (value == "") {
        this.organizationUnitID = "";
        this.$refs.pagination.selectFirstPage();
        this.getSalaryCompositionByFilter(
          this.pageIndex,
          this.pageSize,
          this.statusID,
          this.organizationUnitID,
          this.keysearch
        );
      } else {
        this.organizationUnitID = value;
        this.$refs.pagination.selectFirstPage();
        this.getSalaryCompositionByFilter(
          this.pageIndex,
          this.pageSize,
          this.statusID,
          this.organizationUnitID,
          this.keysearch
        );
      }
    },

    /**---------------------------------------------------------
     * Lấy ra số dòng đã được checked
     * CreatedBy: LQNHAT(17/09/2021)
     */
    getRowChecked(selectedRowsData) {
      // clear arr
      this.salaryCompositionIDs = [];
      this.countRowChecked = selectedRowsData.length;
      selectedRowsData.forEach((element) => {
        this.salaryCompositionIDs.push(element.SalaryCompositionID);
      });
    },

    /**-----------------------------------------------------------
     * Hàm bắt sự kiện khi có text thì search theo text
     * CreateBy: LQNhat(20/09/2021)
     */
    searchByKeysearch() {
      if (this.keysearch == "") {
        this.reloadTableAndFilter();
      } else {
        this.$refs.pagination.selectFirstPage();
        this.getSalaryCompositionByFilter(
          this.pageIndex,
          this.pageSize,
          this.statusID,
          this.organizationUnitID,
          this.keysearch
        );
      }
    },

    /*---------------------------------------------------------
     * Bắt sự kiện bỏ chọn
     * CreatedBy:LQNHAT(17/09/2021)
     */
    uncheckAll() {
      this.$refs.baseGrid.uncheckAllRow();
    },

    /**
     * Hàm format lương trên table
     * CreateBy:LQNhat(17/09/2021)
     */
    formatPrice(value) {
      if (value == 0) {
        return "-";
      } else {
        let val = (value / 1).toFixed(0).replace(".", ",");
        return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
      }
    },
  },
};
</script>

<style>
</style>