<template>
  <div class="box-filter" :class="{ 'hidden-filter': hiddenPopupFilter }">
    <div class="wrapper-filter">
      <div class="header-filter flex a-l-c">
        <div class="text-header">Bộ lọc</div>
        <div class="box-icon-close" @click="closePopupFilter">
          <div class="icon-close-filter"></div>
        </div>
      </div>
      <div class="box-search relative box-search-filter">
        <input
          type="text"
          class="m-input input-search input-search-filter"
          placeholder="Tìm kiếm"
        />
        <div class="icon-search-filter"></div>
      </div>
      <div class="content-filter">
        <div v-for="element in headers" :key="element.DataField">
          <div
            class="box-item-filter"
            :class="{
              'background-box-item': element.Checked,
              'size-box-item': element.Checked,
            }"
          >
            <div
              class="item-filter relative flex a-l-c"
              @click="toggleCheckbox(element)"
            >
              <div
                class="icon-checkbox-filter-default"
                :class="{
                  'icon-checkbox-filter-default': !element.Checked,
                  'icon-checkboc-filter-checked': element.Checked,
                }"
              ></div>
              <div class="text-checkbox-column">{{ element.Caption }}</div>
            </div>
            <div class="box-selectBox" v-if="element.Checked == true">
              <BaseSelectBox
                style="margin-right: 7px; width: 235px"
                :displayExprProp="'FilterName'"
                :valueExprProp="'FilterID'"
                :dataSource="dataSourceFilter"
                :valueDefault="dataSourceFilter[2].FilterID"
                :disabledProp="false"
                v-model="filter.FilterID"
              />
            </div>
            <div class="box-input-filter" v-if="element.Checked == true">
              <input
                type="text"
                class="m-input input-search input-filter"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import BaseSelectBox from "./BaseSelectBox.vue";
import { FILTER } from "../../js/common/data.js";
export default {
  // props: ["hiddenPopupFilter", "headers"],
  props:{
    hiddenPopupFilter: {
      type: Boolean,
    },
    headers: {
      type: Array
    }
  },
  components: {
    BaseSelectBox,
  },
  data() {
    return {
      dataSourceFilter: FILTER,
      filter:{FilterID : 3},
    };
  },
  methods: {
    /**----------------------------------
     * Đóng popup filter
     * CreatedBy:LQNHAT(20/09/2021)
     */
    closePopupFilter() {
      this.$emit("closePopupFilter");
    },
    /**------------------------------------
     * Toggle checkbox icon
     * CreatedBy:LQNHAT(20/09/2021)
     */
    toggleCheckbox(element) {
      element.Checked = !element.Checked;
    },
  },
};
</script>

<style>
</style>