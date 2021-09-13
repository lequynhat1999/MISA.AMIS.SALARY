<template>
  <div class="dx-field-value">
    <DxDropDownBox
      :value="treeBoxValue"
      :opened="isTreeBoxOpened"
      :show-clear-button="true"
      :data-source="treeDataSource"
      value-expr="ID"
      display-expr="name"
      placeholder="Select a value..."
      @value-changed="syncTreeViewSelection($event)"
    >
      <template #content="{}">
        <DxTreeView
          :searchEnabled="true"
          :ref="treeViewRefName"
          :data-source="treeDataSource"
          :select-by-click="true"
          data-structure="plain"
          key-expr="ID"
          parent-id-expr="categoryId"
          selection-mode="single"
          display-expr="name"
          @content-ready="$event.component.selectItem(treeBoxValue)"
          @item-selection-changed="treeView_itemSelectionChanged($event)"
          @item-click="onTreeItemClick($event)"
        />
      </template>
    </DxDropDownBox>
  </div>
</template>

<script>
import DxDropDownBox from "devextreme-vue/drop-down-box";
import DxTreeView from "devextreme-vue/tree-view";
export default {
  name: "BaseDropdownSingle",
  components: {
    DxDropDownBox,
    DxTreeView,
  },
  data() {
      return {
          treeDataSource: null,
          treeBoxValue: null,
          isTreeBoxOpened: false,
          treeViewRefName: "tree-view",
      }
  },
};
</script>

<style>
</style>